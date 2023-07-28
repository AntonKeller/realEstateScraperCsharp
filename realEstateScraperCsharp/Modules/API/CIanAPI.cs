using Microsoft.Playwright;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace realEstateScraperCsharp.Modules.API
{

    // Набор констант для работы с сайтом циан
    class CianConstants
    {
        public static Dictionary<string, string> SerpFrontendTotalOffers = new()
        {
            ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.totalOffers",
            ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.totalOffers",
        };

        // Словарь скриптов для получения данных со страницы циан
        public static Dictionary<string, string> SerpFrontendOffers = new()
        {
            ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.offers",
            ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.offers",
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

    internal static class CianAPI
    {
        private static readonly string PathRegions = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_regions.json");
        private static readonly string PathCities = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_cities.json");
        private static readonly string PathDistricts = Path.Combine(Directory.GetCurrentDirectory(), "Modules", "API", "dataSource", "cian_districts.json");

        private static async Task<string> ReadJsonFile(string path)
        {
            var fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static async Task<RegionStructure[]> GetCianRegions(IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathRegions);
            return JsonConvert.DeserializeObject<RegionStructure[]>(fileStr);
        }

        public static async Task<CityStructure> GetCianCitiesByRegionId(int regionId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathCities);
            var respArrDistr = JsonConvert.DeserializeObject<CityStructure[]>(fileStr);
            return Array.Find<CityStructure>(respArrDistr, (e) => e.Region_id == regionId);
        }

        public static async Task<DistrictStructure> GetCianDistrictsByCityId(int cityId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathDistricts);
            var respArrDistr = JsonConvert.DeserializeObject<DistrictStructure[]>(fileStr);
            return Array.Find<DistrictStructure>(respArrDistr, (e) => e.City_id == cityId);
        }

        //public async Task<List<string>> PageLinksGeneratorByConfig()

        public static async Task<List<PageLink>> PageLinksGenerator(IPage page, string baseURL)
        {
            if (IsNull(page, baseURL)) return null;


            await page.GotoAsync(baseURL + "&p=1");
            string fieldName = await WhatIsFieldNameSerp(page, baseURL);
            if (!CianConstants.SerpFrontendTotalOffers.ContainsKey(fieldName)) return null;
            var totalOffers = await page.EvaluateAsync<int?>(CianConstants.SerpFrontendTotalOffers[fieldName]);
            if (totalOffers == null) return null;

            //| Определяем кол-во страниц
            var maxPages = (int)Math.Floor((decimal)totalOffers / 28);
            maxPages = maxPages > 54 ? 54 : maxPages;

            //| Генерируем страницы
            List<PageLink> pageLinkListFinaly = new();

            for (int i = 0; i <= maxPages; i++)
                pageLinkListFinaly.Add(new PageLink($"{baseURL}&p={i + 1}", false, null));

            return pageLinkListFinaly;
        }

        private static bool IsNull(IPage page, string url) => page == null || url == null;

        private static async Task<string> WhatIsFieldNameSerp(IPage page, string url)
        {
            if (IsNull(page, url)) throw new Exception("Класс: CianAPI.\t Метод: WhatIsFieldNameSerp.\t Исключение: page или url = null");
            await page.GotoAsync(url);
            var script = "Object.keys(window._cianConfig).find(key => key.toLowerCase().indexOf(\"serp\") !== -1)";
            return await page.EvaluateAsync<string>(script);
        }

        public static async Task<CianOffer[]> LoadOffersFromPage(IPage page, string url)
        {
            if (IsNull(page, url)) throw new Exception("Класс: CianAPI.\t Метод: LoadOffersFromPage.\t Исключение: page или url = null");
            if (IsNull(page, url)) return null;
            string fieldName = await WhatIsFieldNameSerp(page, url);
            if (!CianConstants.SerpFrontendOffers.ContainsKey(fieldName)) return null;
            return await page.EvaluateAsync<CianOffer[]>(CianConstants.SerpFrontendOffers[fieldName]);
        }

        private static DistrictStructure SearchDistrictInObject(DistrictStructure inObj, string name, string type)
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

        public static DistrictStructure SearchDistrictInArray(DistrictStructure[] inObjArr, string name, string type)
        {
            for (int i = 0; i < inObjArr.Length; i++)
            {
                var districtStruct = SearchDistrictInObject(inObjArr[i], name, type);
                if (districtStruct != null) return districtStruct;
            }
            return null;
        }
        
        public static string ShorterOkrugMSK(string okrug)
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
}
