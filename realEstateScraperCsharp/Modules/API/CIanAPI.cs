using Microsoft.Playwright;
using Newtonsoft.Json;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace realEstateScraperCsharp.Modules.API
{

    // Набор констант для работы с сайтом циан
    class CianConstants
    {
        // Словарь скриптов для получения данных со страницы циан
        public static Dictionary<string, string> SerpFrontend = new()
        {
            ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.totalOffers",
            ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.totalOffers",
        };
    }
    
    class Coordinates
    {
        public float? Lat { get; set; }
        public float? Lng { get; set; }
    }


    class BoundedByType
    {
        public Coordinates LowerCorner { get; set; }
        public Coordinates UpperCorner { get; set; }
    }

    class CianUnit
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    class CianTerritorialUnit : CianUnit
    {
        public int? ParentId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public bool? HasDistricts { get; set; }
        public bool? HasMetro { get; set; }
        public bool? HasHighway { get; set; }
        public bool? HasNeighbors { get; set; }
        public BoundedByType BoundedBy { get; set; }
    }

    class RegionStructure : CianTerritorialUnit
    {
        public int? MainTownId { get; set; }
        public string BaseHost { get; set; }
        public string PrepositionalPretext { get; set; }
        public string FullNamePrepositional { get; set; }
    }

    class CityStructure : CianTerritorialUnit
    {
        public int? Region_id { get; set; }
        public int? MainTownId { get; set; }
    }

    class DistrictStructure : CianUnit
    {
        public int? Region_id { get; set; }
        public int? City_id { get; set; }
        public string Type { get; set; }
        public DistrictStructure[] Childs { get; set; }
    }

    class LinksGeneration
    {
        public int? MaxOffers { get; set; }
        public int? MaxPages { get; set; }
        public List<string> Links { get; set; }
        public LinksGeneration(int? maxOffers, int? maxPages, List<string> links)
        {
            this.MaxOffers = maxOffers;
            this.MaxPages = maxPages;
            Links = new List<string>(links);
        }
    }

    internal class CianAPI
    {
        private readonly string PathRegions = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_regions.json");
        private readonly string PathCities = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_cities.json");
        private readonly string PathDistricts = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_districts.json");

        private async Task<string> ReadJsonFile(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public async Task<RegionStructure[]> GetCianRegions(IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathRegions);
            return JsonConvert.DeserializeObject<RegionStructure[]>(fileStr);
        }

        public async Task<CityStructure> GetCianCitiesByRegionId(int regionId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathCities);
            var respArrDistr = JsonConvert.DeserializeObject<CityStructure[]>(fileStr);
            return Array.Find<CityStructure>(respArrDistr, (e) => e.Region_id == regionId);
        }

        public async Task<DistrictStructure> GetCianDistrictsByCityId(int cityId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathDistricts);
            var respArrDistr = JsonConvert.DeserializeObject<DistrictStructure[]>(fileStr);
            return Array.Find<DistrictStructure>(respArrDistr, (e) => e.City_id == cityId);
        }

        //public async Task<List<string>> PageLinksGeneratorByConfig()

        public async Task<LinksGeneration> PageLinksGenerator(IPage page, string baseURL)
        {
            if (IsNull(page, baseURL)) return null;
            await page.GotoAsync(baseURL + "&p=1");
            string fieldName = await WhatIsFieldNameSerp(page, baseURL);
            if (!CianConstants.SerpFrontend.ContainsKey(fieldName)) return null;
            var totalOffers = await page.EvaluateAsync<int?>(CianConstants.SerpFrontend[fieldName]);
            if (totalOffers == null) return null;

            //| Определяем кол-во страниц
            var maxPages = (int)Math.Floor((decimal)totalOffers / 28);
            maxPages = maxPages > 54 ? 54 : maxPages;

            //| Генерируем страницы
            var links = new List<string>();
            for (int i = 0; i <= maxPages; i++)
                links.Add($"{baseURL}&p={i}");

            return new LinksGeneration(totalOffers, maxPages, links);
        }

        private bool IsNull(IPage page, string url) => page == null || url == null;

        private async Task<string> WhatIsFieldNameSerp(IPage page, string url)
        {
            if (IsNull(page, url)) throw new Exception("Класс: CianAPI.\t Метод: WhatIsFieldNameSerp.\t Исключение: page или url = null");
            await page.GotoAsync(url);
            var script = "Object.keys(window._cianConfig).find(key => key.toLowerCase().indexOf(\"serp\") !== -1)";
            return await page.EvaluateAsync<string>(script);
        }

        public async Task<CianOffer[]> LoadOffersFromPage(IPage page, string url)
        {
            if (IsNull(page, url)) throw new Exception("Класс: CianAPI.\t Метод: LoadOffersFromPage.\t Исключение: page или url = null");
            if (IsNull(page, url)) return null;
            string fieldName = await WhatIsFieldNameSerp(page, url);
            if (!CianConstants.SerpFrontend.ContainsKey(fieldName)) return null;
            return await page.EvaluateAsync<CianOffer[]>(CianConstants.SerpFrontend[fieldName]);
        }

        private DistrictStructure SearchDistrictInObject(DistrictStructure inObj, string name, string type)
        {
            if (Regex.IsMatch(inObj.Name, name, RegexOptions.IgnoreCase) && Regex.IsMatch(inObj.Type, type, RegexOptions.IgnoreCase))
            {
                return inObj;
            }
            
            if (inObj?.Childs?.Length > 0)
            {
                var districtStruct = SearchDistrictInArray(inObj.Childs, name, type);
                if (districtStruct != null) return districtStruct;
            }

            return null;
        }

        public DistrictStructure SearchDistrictInArray(DistrictStructure[] inObjArr, string name, string type)
        {
            for (int i = 0; i < inObjArr.Length; i++)
            {
                var districtStruct = SearchDistrictInObject(inObjArr[i], name, type);
                if (districtStruct != null) return districtStruct;
            }
            return null;
        }
        
        public string ShorterOkrugMSK(string okrug)
        {
            var dictionary = new Dictionary<string, string>()
            {
                ["Восточный".ToLower()] = "ВАО".ToLower(),
                ["Западный".ToLower()] = "ЗАО".ToLower(),
                ["Зеленоградский".ToLower()] = "ЗелАО".ToLower(),
                ["Северный".ToLower()] = "САО".ToLower(),
                ["Северо-Восточный".ToLower()] = "СВАО".ToLower(),
                ["Северо-Западный".ToLower()] = "СЗАО".ToLower(),
                ["Центральный".ToLower()] = "ЦАО".ToLower(),
                ["Юго-Восточный".ToLower()] = "ЮВАО".ToLower(),
                ["Юго-Западный".ToLower()] = "ЮЗАО".ToLower(),
                ["Южный".ToLower()] = "ЮАО".ToLower(),
                ["Новомосковский".ToLower()] = "НАО".ToLower()
            };
            return dictionary.ContainsKey(okrug.ToLower()) ? dictionary[okrug.ToLower()] : null;
        }
    }

    // Список ошибок
    class SelfErrors
    {
        public static string IntervalConstructorIsNull = "Конструктор Interval: self == null!";
    }

    // Класс для переменных с интервальным значением
    class Interval
    {
        public double? Min;
        public double? Max;
        public Interval(double? min = null, double? max = null)
        {
            this.Min = min;
            this.Max = max;
        }
        public Interval(Interval self)
        {
            if (self == null) throw new Exception(SelfErrors.IntervalConstructorIsNull);
            this.Min = self.Min;
            this.Max = self.Max;
        }
    }

    //Базовые URL адреса (общие)
    class Domain
    {
        public static readonly string BASE = "https://www.cian.ru/cat.php?";
        public static readonly string LAND_SALE = BASE + "cats%5B0%5D=commercialLandSale";
        public static readonly string LAND_RENT = BASE + "cats%5B0%5D=commercialLandRent";
        public static readonly string ENGINE = "engine_version=2";
    }

    // Параметр: "Тип офиса"
    class OfficeType
    {
        // Для Офисных помещений
        public static readonly string OFFICE = "&office_type=1";
        // Для Торговых площадей
        public static readonly string TRADE_AREA = "&office_type=2";
        // Для Складов
        public static readonly string WAREHOUSE = "&office_type=3";
        // Для Производственных помещений
        public static readonly string INDUSTRIAL_PERM = "&office_type=7";
        // Для зданий
        public static readonly string BUILDING = "&office_type%5B0%5D=11";
        // Для помещений свободного назначения (псн.)
        public static readonly string VACANT_PERM = "&office_type=5";
        // Для готового бизнеса
        public static readonly string READY_BUSINESS = "&office_type=10";
        // Для гаражей
        public static readonly string GARAGE = "&office_type=6";
    }

    class OfferType
    {
        public static readonly string OSUBURBAN = "&offer_type=suburban";
        public static readonly string OFFICE = "&offer_type=offices";
        public static readonly string FLAT = "&offer_type=flat";
    }

    class DealType
    {
        public static readonly string SALE = "&deal_type=sale";
        public static readonly string RENT = "&deal_type=rent";
    }


    // Базовые URL адреса для объектов недвижимости ~~ Переименовать по смыслу
    internal class BaseCategories
    {
        // Базый URL для офисов [Аренда, Продажа]
        public static readonly string OFFICE_SALE = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.OFFICE + DealType.SALE;
        public static readonly string OFFICE_RENT = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.OFFICE + DealType.RENT;

        // Базый URL для торговых площадей
        public static readonly string TRADE_AREA_SALE = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.TRADE_AREA + DealType.SALE;
        public static readonly string TRADE_AREA_RENT = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.TRADE_AREA + DealType.RENT;

        // Базый URL для гаражей
        public static readonly string GARAGE_SALE = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.GARAGE + DealType.SALE;
        public static readonly string GARAGE_RENT = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.GARAGE + DealType.RENT;

        // Базый URL для складов
        public static readonly string WAREHOUSE_SALE = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.WAREHOUSE + DealType.SALE;
        public static readonly string WAREHOUSE_RENT = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.WAREHOUSE + DealType.RENT;

        // Базый URL для ПСН.
        public static readonly string VACANT_PERM_SALE = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.VACANT_PERM + DealType.SALE;
        public static readonly string VACANT_PERM_RENT = Domain.BASE + Domain.ENGINE + OfferType.OFFICE + OfficeType.VACANT_PERM + DealType.RENT;

        // Базый URL для Земли
        public static readonly string LAND_SALE = Domain.LAND_SALE + Domain.ENGINE + OfferType.OFFICE + DealType.SALE;
        public static readonly string LAND_RENT = Domain.LAND_RENT + Domain.ENGINE + OfferType.OFFICE + DealType.RENT;
    }

    /*
            Генератор призван по запросу сгенерировать URL список, 
            который будет отправлен в загрузчик предложений по этим ссылкам.
            .........................................................
            В конструкторе задаются:
                - Список базовых URL адресов. ( у которых нет параметров (кроме базовых: тип предложения, тип сделки и т.д) )
                - Некоторые ограничения ( Например класс помещений "А+ .. С" ).
            (Базовый URL -> ведет на первую страницу результата поиска по параметрам)
            .........................................................................
            Пример:
                Ссылка: https://www.cian.ru/cat.php?building_class_type%5B0%5D=3&deal_type=rent&engine_version=2&offer_type=offices&office_type%5B0%5D=2&region=1
                Параметры:
                    -https://www.cian.ru/cat.php?
                    -building_class_type%5B0%5D=3
                    -&deal_type=rent
                    -&engine_version=2
                    -&offer_type=offices
                    -&office_type%5B0%5D=2
                    -&region=1
            .........................................................................
            ~ На текущем этапе нам не нужен парсер, посколько данный модуль ответственнен исключительно за генерацию URL по параметрам.
        */

    interface IGeneratorURL
    {
        Task<List<string>> Generate(IPage page);
    }


    internal class SimpleGeneratorURL : IGeneratorURL
    {

        // Базовые ссылки, на которые будем накладывать параметры
        // (Включают стандартные параметры: Домен, Движок, Тип предложения, Тип сделки)
        // Остается включить доп. параметры (Ограничения по площадям, классам помещений и т.д)
        private List<string> CategoryListURL;

        // Параметры фильтрующие поиске предложения по площадям
        //      1. Площадь помещения
        //      2. Площадь земли
        private string PermAreaMin;
        private string PermAreaMax;
        private string LandAreaMin;
        private string LandAreaMax;

        // Параметры - Классы недвижимости | x > 0
        private List<string> PermClasses;


        //| Будет хранить описание данного конфигуратора
        private readonly string Description;

        //| Будет хранить список сгенерированных URL
        private List<string> ListURL;

        // Возвращает список сгененрированных URL
        public List<string> GetListURL() => new List<string>(ListURL);

        // Конструктор 1
        public SimpleGeneratorURL(              // В конструкторе задаем параметры генерации - Списка URL
            string description,                 // Описание
            List<string> categoryListURL, // Список базовых ссылок (Включает стандартные параметры: Домен, Движок, Тип предложения, Тип сделки)
            List<string> PermClasses,           // Классы помещения
            Interval permAreaI,                 // Интервал площади помещения
            Interval landAreaI                  // Интервал площади земли
            )
        {

            // Описание текущего генератора
            this.Description = description;

            // Инициализация списка с базовыми ссылками с базовыми параметрами
            if (categoryListURL == null || categoryListURL.Count <= 0)
                throw new ArgumentException("Класс SimpleGeneratorURL. Конструктор. categoryListURL <= 0 || null");
            else
                this.CategoryListURL = new List<string>(categoryListURL);

            // Инициализация ограничений площади помещения и площади земли
            this.PermAreaMin = permAreaI.Min != null ? $"&minarea={permAreaI.Min}" : "";
            this.PermAreaMax = permAreaI.Max != null ? $"&maxarea={permAreaI.Max}" : "";
            this.LandAreaMin = landAreaI.Min != null ? $"&minsite={landAreaI.Min}" : "";
            this.LandAreaMax = landAreaI.Max != null ? $"&maxsite={landAreaI.Max}" : "";

            // Инициализация параметра: классы недвижимости
            this.PermClasses = (PermClasses != null && PermClasses.Count > 0) ? new List<string>(PermClasses) : new List<string>() { "" };
        }

        // Конструктор 2
        public SimpleGeneratorURL(SimpleGeneratorURL self)
        {
            // Копируем все значения
            this.Description = self.Description;
            this.PermAreaMin = self.PermAreaMin;
            this.PermAreaMax = self.PermAreaMax;
            this.LandAreaMin = self.LandAreaMin;
            this.LandAreaMax = self.LandAreaMax;
            this.PermClasses = new List<string>(self.PermClasses);
            this.ListURL = new List<string>(self.ListURL);
        }


        public async Task<List<string>> Generate(IPage page)
        {
            GenerationUpdate(page);
            return new List<string>(ListURL);
        }


        // Занимается генерацией URL
        public async void GenerationUpdate(IPage page)
        {
            this.ListURL = new();

            if (page == null) throw new Exception("Класс: SimpleGeneratorURL. Функция: Generate. page == null");

            // ... обработать исключения

            for (int i = 0; i < this.CategoryListURL.Count; i++)
            {
                var url = CategoryListURL[i];

                // Добавляем параметр класс недвижимости 
                for (int j = 0; j < this.PermClasses.Count; j++)
                {
                    ListURL.Add($"{url}{PermClasses[j]}{this.PermAreaMin}{this.PermAreaMax}");
                    ListURL.Add($"{url}{PermClasses[j]}{this.LandAreaMin}{this.LandAreaMax}");
                }
            }

        }

    }

    // Хранилище некоторого множества генераторов
    internal class ConfigurationStore
    {

        // Хранит в себе некоторое множество генераторов URL Списков
        private List<SimpleGeneratorURL> ListGenerators;

        public ConfigurationStore(SimpleGeneratorURL generator)
        {
            this.ListGenerators = new() { generator };
        }

        public ConfigurationStore()
        {
            this.ListGenerators = new();
        }

        public ConfigurationStore(ConfigurationStore self)
        {
            this.ListGenerators = new(self.ListGenerators);
        }

    }
}
