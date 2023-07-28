using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realEstateScraperCsharp.Modules
{
    
    // Класс базовых параметров, доменов и url
    class Domain 
    {
        public static readonly string BASE = "https://www.cian.ru/cat.php?"; // Базовый домен
        public static readonly string LAND_SALE = BASE + "cats%5B0%5D=commercialLandSale"; // Домен продажа земли
        public static readonly string LAND_RENT = BASE + "cats%5B0%5D=commercialLandRent"; // Домен аренда земли
        public static readonly string ENGINE = "engine_version=2"; // Параметр движок
    }


    // Класс параметров (Типы предлагаемых помещений)
    class OfficeType 
    {
        public static readonly string OFFICE = "&office_type=1"; // Офисные помещения
        public static readonly string TRADE_AREA = "&office_type=2"; // Торговые площади
        public static readonly string WAREHOUSE = "&office_type=3"; // Склады
        public static readonly string INDUSTRIAL_PERM = "&office_type=7"; // Производственные помещения
        public static readonly string BUILDING = "&office_type%5B0%5D=11"; // Здания, строения
        public static readonly string VACANT_PERM = "&office_type=5"; // Помещения свободного назначения (псн.)
        public static readonly string READY_BUSINESS = "&office_type=10"; // Готовый бизнес
        public static readonly string GARAGE = "&office_type=6"; // Гаражи
    }


    // Класс параметров (Типы предложений)
    class OfferType 
    {
        public static readonly string SUBURBAN = "&offer_type=suburban"; // Дома, дачи
        public static readonly string OFFICE = "&offer_type=offices"; // Офисы, магазины и т.д.
        public static readonly string FLAT = "&offer_type=flat"; // Жилые квартиры
    }


    // Класс параметров (Типы сделок)
    class DealType 
    {
        public static readonly string SALE = "&deal_type=sale"; // Продажа
        public static readonly string RENT = "&deal_type=rent"; // Аренда
    }


    // Класс параметров (Типы отделки помещений)
    public class StaticPermClasses
    {
        public static readonly string Aplus = "&building_class_type%5B0%5D=2";
        public static readonly string A = "&building_class_type%5B0%5D=1";
        public static readonly string Bplus = "&building_class_type%5B0%5D=4";
        public static readonly string B = "&building_class_type%5B0%5D=3";
        public static readonly string Bminus = "&building_class_type%5B0%5D=8";
        public static readonly string C = "&building_class_type%5B0%5D=5";
    }


    // Базовые URL адреса для объектов недвижимости ~~ Переименовать по смыслу
    public class BaseCategories
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

    public class ConfigDictionaries
    {
        // Словарь "Категории недвижимости"
        public static Dictionary<string, string> DicCategories = new()
        {
            ["Продажа офисов"] = BaseCategories.OFFICE_SALE,
            ["Аренда офисов"] = BaseCategories.OFFICE_RENT,
            ["Продажа гаражей"] = BaseCategories.GARAGE_SALE,
            ["Аренда гаражей"] = BaseCategories.GARAGE_RENT,
            ["Продажа складов"] = BaseCategories.WAREHOUSE_SALE,
            ["Аренда складов"] = BaseCategories.WAREHOUSE_RENT,
            ["Продажа торговых площадей"] = BaseCategories.TRADE_AREA_SALE,
            ["Аренда торговых площадей"] = BaseCategories.TRADE_AREA_RENT,
            ["Продажа ПСН."] = BaseCategories.VACANT_PERM_SALE,
            ["Аренда ПСН."] = BaseCategories.VACANT_PERM_RENT,
            ["Продажа земли"] = BaseCategories.LAND_SALE,
            ["Аренда земли"] = BaseCategories.LAND_RENT,
        };


        // Инвертированный словарь "Категории недвижимости"
        public static Dictionary<string, string> InvertDicCategories = new()
        {
            [BaseCategories.OFFICE_SALE] = "Продажа офисов",
            [BaseCategories.OFFICE_RENT] = "Аренда офисов",
            [BaseCategories.GARAGE_SALE] = "Продажа гаражей",
            [BaseCategories.GARAGE_RENT] = "Аренда гаражей",
            [BaseCategories.WAREHOUSE_SALE] = "Продажа складов",
            [BaseCategories.WAREHOUSE_RENT] = "Аренда складов",
            [BaseCategories.TRADE_AREA_SALE] = "Продажа торговых площадей",
            [BaseCategories.TRADE_AREA_RENT] = "Аренда торговых площадей",
            [BaseCategories.VACANT_PERM_SALE] = "Продажа ПСН.",
            [BaseCategories.VACANT_PERM_RENT] = "Аренда ПСН.",
            [BaseCategories.LAND_SALE] = "Продажа земли",
            [BaseCategories.LAND_RENT] = "Аренда земли",
        };


        // Словарь "Классы отделки помещения"
        public static Dictionary<string, string> DicPermClasses = new()
        {
            ["Продажа офисов"] = StaticPermClasses.Aplus,
            ["Аренда офисов"] = StaticPermClasses.A,
            ["Продажа гаражей"] = StaticPermClasses.Bplus,
            ["Аренда гаражей"] = StaticPermClasses.B,
            ["Продажа складов"] = StaticPermClasses.Bminus,
            ["Аренда складов"] = StaticPermClasses.C,
        };
         

        // Инвертированный cловарь "Классы отделки помещения"
        public static Dictionary<string, string> InvertDicPermClasses = new()
        {
            [StaticPermClasses.Aplus] = "Продажа офисов",
            [StaticPermClasses.A] = "Аренда офисов",
            [StaticPermClasses.Bplus] = "Продажа гаражей",
            [StaticPermClasses.B] = "Аренда гаражей",
            [StaticPermClasses.Bminus] = "Продажа складов",
            [StaticPermClasses.C] = "Аренда складов",
        };
    }


    // Класс конфигурации
    internal class RealEstateConfig 
    {
        public string Category { get; set; }
        public string RegionID { get; set; }
        public string CityID { get; set; }
        public string DistrictID { get; set; }
        public double? PermAreaMin { get; set; }
        public double? PermAreaMax { get; set; }
        public double? LandAreaMin { get; set; }
        public double? LandAreaMax { get; set; }
        public List<string> PermClasses { get; set; }

        public RealEstateConfig() { }

        public RealEstateConfig(RealEstateConfig config)
        {
            Category = config.Category;
            RegionID = config.RegionID;
            CityID = config.CityID;
            DistrictID = config.DistrictID;
            PermAreaMin = config.PermAreaMin;
            PermAreaMax = config.PermAreaMax;
            LandAreaMin = config.LandAreaMin;
            LandAreaMax = config.LandAreaMax;
            PermClasses = new List<string>(config.PermClasses);
        }

        public RealEstateConfig(string category, string regionID, string cityID, string districtID, double? permAreaMin, double? permAreaMax, double? landAreaMin, double? landAreaMax, List<string> permClasses)
        {
            Category = category;
            RegionID = regionID;
            CityID = cityID;
            DistrictID = districtID;
            PermAreaMin = permAreaMin;
            PermAreaMax = permAreaMax;
            LandAreaMin = landAreaMin;
            LandAreaMax = landAreaMax;
            PermClasses = new List<string>(permClasses);
        }
    }
}
