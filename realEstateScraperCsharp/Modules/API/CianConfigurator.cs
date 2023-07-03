using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realEstateScraperCsharp.Modules.API
{
    class IntervalType
    {
        public double? Min;
        public double? Max;
        public IntervalType(double? min, double? max)
        {
            if (min == null || max == null || max < min)
                throw new ArgumentNullException("Некорректные данные! (Конструктор: IntervalType)");
            this.Min = min;
            this.Max = max;
        }
        public IntervalType(IntervalType intervalType)
        {
            this.Min = intervalType.Min;
            this.Max = intervalType.Max;
        }
    }

    class BuildCLass
    {
        public string Description { get; set; }
        public string Parameter { get; set; }
        public BuildCLass(string description, string parameter)
        {
            this.Parameter = parameter;
            this.Description = description;
        }
        public BuildCLass(BuildCLass buildCLass)
        {
            this.Parameter = buildCLass.Parameter;
            this.Description = buildCLass.Description;
        }
    }

    interface IConfig<T>
    {
        List<string> GetUrlList();
        T GetModel();
    }

    class CommercialConfig<T> : IConfig<T>
    {
        //| Описание - позволяет визуально понять с чем мы сейчас работаем
        //| Можно использовать для логов
        //| Определяется в конструкторе
        private readonly string Description;

        //| Отдельные параметры по которым происходит генерация ссылок
        private readonly string BaseUrl;
        private readonly List<BuildCLass> BuildCLasses;
        private readonly IntervalType AreaLandRestriction;
        private readonly IntervalType AreaBuildRestriction;
        private readonly IntervalType PriceRestriction;

        //| Список базовых ссылок сгенерированных по параметрам.
        //| Определяется в конструкторе
        private readonly List<string> UrlList;

        //| Модель, которая включает методы парсинга, поля и т.д.
        //| Должна быть включена в каждый конфиг.
        //| Определяется в конструкторе
        private readonly T Model;
        public T GetModel() => Model;
        //| ....................................................
        public List<string> GetUrlList() => new (this.UrlList);

        //| ....................................................
        private void GenerateUrlList()
        {
            this.BaseLinks = new List<string>();
            // Площадь для земли в кв. м.
            var areaMin = AreaLandRestriction?.Min != null  ? $"minsite={AreaLandRestriction?.Min}": "";
            var areaMax = AreaLandRestriction?.Max != null ? $"&maxsite={AreaLandRestriction?.Max}" : "";
            var areaBuildMin = AreaBuildRestriction?.Min != null ? $"&minarea={AreaBuildRestriction?.Min}" : "";
            var areaBuildMax = AreaBuildRestriction?.Max != null ? $"&maxarea={AreaBuildRestriction?.Max}" : "";
            var priceMin = PriceRestriction?.Min != null ? $"&minprice={PriceRestriction?.Min}" : "";
            var priceMax = PriceRestriction?.Max != null ? $"&maxprice={PriceRestriction?.Max}" : "";

            foreach (var bCLass in this.BuildCLasses)
            {
                var p = this.BaseUrl +
                    bCLass.Parameter +
                    areaMin + areaMax +
                    areaBuildMin + areaBuildMax +
                    priceMin + priceMax;
                BaseLinks.Add(p);
                Console.WriteLine(p);
            }
        }

        public CommercialConfig(
            string description = null,
            string baseUrl = null,
            List<BuildCLass> buildCLasses = null,
            IntervalType areaLandRestriction = null,
            IntervalType areaBuildRestriction = null,
            IntervalType priceRestriction = null
        )
        {
            this.Description = description;
            this.BaseUrl = baseUrl;
            this.BuildCLasses = new List<BuildCLass>(buildCLasses);
            this.AreaLandRestriction = new IntervalType(areaLandRestriction);
            this.AreaBuildRestriction = new IntervalType(areaBuildRestriction);
            this.PriceRestriction = new IntervalType(priceRestriction);
            GenerateUrlList();
        }

        public CommercialConfig(CommercialConfig<T> commercialConfig)
        {
            this.Description = commercialConfig.Description;
            this.BaseUrl = commercialConfig.BaseUrl;
            this.BuildCLasses = new List<BuildCLass>(commercialConfig.BuildCLasses);
            this.AreaLandRestriction = new IntervalType(commercialConfig.AreaLandRestriction);
            this.AreaBuildRestriction = new IntervalType(commercialConfig.AreaBuildRestriction);
            this.PriceRestriction = new IntervalType(commercialConfig.PriceRestriction);
            GenerateUrlList();
        }
    }

    class Constants
    {
        public static readonly string BASE_URL_AREA_SALE = "https://www.cian.ru/cat.php?cats%5B0%5D=commercialLandSale&engine_version=2";
        public static readonly string BASE_URL_AREA_RENT = "https://www.cian.ru/cat.php?cats%5B0%5D=commercialLandRent&engine_version=2";
        public static readonly string BASE_URL = "https://www.cian.ru/cat.php?&engine_version=2";
        public static readonly string OFFER_TYPE_SUBURBAN = "&offer_type=suburban";
        public static readonly string OFFER_TYPE_OFFICES = "&offer_type=offices";
        public static readonly string OFFER_TYPE_FLAT = "&offer_type=flat";
        public static readonly string DEAL_SALE = "&deal_type=sale";
        public static readonly string DEAL_RENT = "&deal_type=rent";
        public static readonly string OFFICE_MIN_AREA = "&minarea=";  //| в квадратных метрах
        public static readonly string OFFICE_MAX_AREA = "&maxarea=";  //| в квадратных метрах
        public static readonly string LAND_MIN_AREA = "&minsite=";    //| параметр принимает единицы только в сотках
        public static readonly string LAND_MAX_AREA = "&maxsite=";    //| параметр принимает единицы только в сотках
    }

    internal class CommercialConfigurator
    {


        //...................................
        public CommercialConfig<OfficeCardModel> OfficeSale;
        public CommercialConfig<OfficeCardModel> OfficeRent;
        public CommercialConfig<OfficeCardModel> TradeAreaSale;
        public CommercialConfig<OfficeCardModel> TradeAreaRent;
        public CommercialConfig<OfficeCardModel> WarehousesSale;
        public CommercialConfig<OfficeCardModel> WarehousesRent;
        public CommercialConfig<LandCardModel> LandSale;
        public CommercialConfig<LandCardModel> LandRent;
        public CommercialConfig<GarageCardModel> GarageSale;
        public CommercialConfig<GarageCardModel> GarageRent;
        //...................................
        public List<string> BaseLinks;
        //...................................
        public List<string> GenerateBaseLinksAll()
        {
            //var aaa = Office.BaseLinks
            //    .Concat(TradeArea.BaseLinks).ToList()
            //    .Concat(Warehouses.BaseLinks).ToList()
            //    .Concat(Land.BaseLinks).ToList()
            //    .Concat(Garage.BaseLinks).ToList();
            return new List<string>();
        }

        public CommercialConfigurator()
        {
            var buildClasses = new List<BuildCLass>()
            {
                new BuildCLass("A+", "&building_class_type%5B0%5D=1"),
                new BuildCLass("A", "&building_class_type%5B0%5D=2"),
                new BuildCLass("B+", "&building_class_type%5B0%5D=3"),
                new BuildCLass("B", "&building_class_type%5B0%5D=4"),
                new BuildCLass("B-", "&building_class_type%5B0%5D=8"),
                new BuildCLass("C", "&building_class_type%5B0%5D=5"),
            };

            var landAreaInterval = new IntervalType(-99999999, 999999999999999.999);
            var BuildAreaInterval = new IntervalType(-99999999, 999999999999999.999);
            var priceValueInterval = new IntervalType(-99999999, 999999999999999.999);

            // Определение конфигурации для офисов
            this.OfficeSale = new CommercialConfig<OfficeCardModel>(
                "Офисы (Продажа)",
                Constants.BASE_URL + Constants.DEAL_SALE + Constants.OFFER_TYPE_OFFICES + "&office_type=1",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            this.OfficeRent = new CommercialConfig<OfficeCardModel>(
                "Офисы (Аренда)",
                Constants.BASE_URL + Constants.DEAL_RENT + Constants.OFFER_TYPE_OFFICES + "&office_type=1",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            // Определение конфигурации для гаражей
            this.GarageSale = new CommercialConfig<GarageCardModel>(
                "Гаражи (Продажа)",
                Constants.BASE_URL + Constants.DEAL_SALE + Constants.OFFER_TYPE_OFFICES + "&office_type=6",
                null,
                landAreaInterval,
                null,
                priceValueInterval
                );

            this.GarageRent = new CommercialConfig<GarageCardModel>(
                "Гаражи (Аренда)",
                Constants.BASE_URL + Constants.DEAL_RENT + Constants.OFFER_TYPE_OFFICES + "&office_type=6",
                null,
                landAreaInterval,
                null,
                priceValueInterval
                );

            // Определение конфигурации для земли
            this.LandSale = new CommercialConfig<LandCardModel>(
                "Земля (Продажа)",
                Constants.BASE_URL_AREA_SALE + Constants.DEAL_SALE + Constants.OFFER_TYPE_OFFICES,
                null,
                landAreaInterval,
                null,
                priceValueInterval
                );

            this.LandRent = new CommercialConfig<LandCardModel>(
                "Земля (Аренда)",
                Constants.BASE_URL_AREA_RENT + Constants.DEAL_RENT + Constants.OFFER_TYPE_OFFICES,
                null,
                landAreaInterval,
                null,
                priceValueInterval
                );

            // Определение конфигурации для торговых площадей
            this.TradeAreaSale = new CommercialConfig<OfficeCardModel>(
                "Торговая площадь (Продажа)",
                Constants.BASE_URL + Constants.DEAL_SALE + Constants.OFFER_TYPE_OFFICES + "&office_type=2",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            this.TradeAreaRent = new CommercialConfig<OfficeCardModel>(
                "Торговая площадь (Аренда)",
                Constants.BASE_URL + Constants.DEAL_RENT + Constants.OFFER_TYPE_OFFICES + "&office_type=2",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            // Склады
            this.WarehousesSale = new CommercialConfig<OfficeCardModel>(
                "Склад (Продажа)",
                Constants.BASE_URL + Constants.DEAL_SALE + Constants.OFFER_TYPE_OFFICES + "&office_type=2",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            this.WarehousesRent = new CommercialConfig<OfficeCardModel>(
                "Склад (Аренда)",
                Constants.BASE_URL + Constants.DEAL_RENT + Constants.OFFER_TYPE_OFFICES + "&office_type=2",
                buildClasses,
                landAreaInterval,
                BuildAreaInterval,
                priceValueInterval
                );

            Configs.Add(this.OfficeSale);
            Configs.Add(this.OfficeRent);
            Configs.Add(this.GarageSale);
            Configs.Add(this.GarageRent);
            Configs.Add(this.LandSale);
            Configs.Add(this.LandRent);
            Configs.Add(this.TradeAreaSale);
            Configs.Add(this.TradeAreaRent);
            Configs.Add(this.WarehousesSale);
            Configs.Add(this.WarehousesRent);
        }
    }
}
