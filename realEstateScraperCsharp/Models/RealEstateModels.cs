using realEstateScraperCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightExtraSharp;
using Microsoft.Playwright;

namespace realEstateScraperCsharp.Models
{
    interface IModelDataProvider
    {
        Task GetData(string url, IPage page);
    }

    interface ISetService
    {
        void SetData(IModelDataProvider modelDataProvider);
    }

    class CianAPIService: IModelDataProvider
    {
        //| Загрузка данных с одной страницы (от 0 до N) шт.
        public async Task GetData(string url, IPage page)
        {
            await page.GotoAsync(url);
        }
    }

    class AvitoAPIService : IModelDataProvider
    {
        //| Загрузка данных с одной страницы (от 0 до N) шт.
        public async Task GetData(string url, IPage page)
        {
            await page.GotoAsync(url);
        }
    }



    class GeneralCardModel
    {
        public int Id { get; set; } //Уникальный id
        public int insideId {get;set;} //Внутренний id (на сайте при наличии)
        public string phoneNumber { get;set; } //Номер телефона
        public string cadNumber { get;set; } //Кадастровый номер
        public string cardUrl { get;set; } //Url карточки (предложения)
        public string publicationDate { get;set; } //Дата публикации
        public string address { get;set; } //Полный адрес местонахождения
        public string lat { get;set; } //Координата широта
        public string lon { get;set; } //Координата долгота
        public string subject { get;set; } //Субъект федерации
        public string munOkrug { get;set; } //Муниципальный округ
        public string munRaion { get;set; } //Муниципальный район
        public string economicZone { get;set; } //Муниципальный район
        public string city { get;set; } //Город
        public string localityType { get;set; } //Тип поселения (при наличии, для Москвы ...)
        public string locality { get;set; } //Наименование поселения (при наличии, для Москвы ...)
        public string okrug { get;set; } //Административный округ
        public string raion { get;set; } //Административный район
        public string mikroraion { get;set; } //Микрорайон
        public string section { get;set; } //Квартал
        public string metroWalkName { get;set; } //Ближайшая станция метро (пешком)
        public int metroWalkDistance { get;set; } //Удаленность от метро (мин. пешком)
        public string metroTransportName { get;set; } //Ближайшая станция метро (транспорт)
        public int metroTransportDistance { get;set; } //Удаленность от метро (мин. транспорт)
        public string description { get;set; } //Описание
        public string dealType { get;set; } //Тип сделки
        public string theCompositionOfTheTransferredRights { get; set; } //Состав передаваемых прав
        public string dealComments { get; set; } //Коментарии к сделке
        public string functionalPurpose { get;set; } //Функциональное назначение
        public string specialty { get;set; } //Варианты использования
        public string vatType { get;set; } //НДС
        public float price { get;set; } //Цена предложения
        public string heatingType { get;set; } //Тип отопления
        public int analogNumber { get;set; } //Номер аналога
        public string parseDate { get;set; } //Дата парсинга

        public GeneralCardModel(GeneralCardModel generalCardModel)
        {
            this.Id = generalCardModel.Id;
            this.insideId = generalCardModel.insideId;
            this.phoneNumber = generalCardModel.phoneNumber;
            this.cadNumber = generalCardModel.cadNumber;
            this.cardUrl = generalCardModel.cardUrl;
            this.publicationDate = generalCardModel.publicationDate;
            this.address = generalCardModel.address;
            this.lat = generalCardModel.lat;
            this.lon = generalCardModel.lon;
            this.subject = generalCardModel.subject;
            this.munOkrug = generalCardModel.munOkrug;
            this.munRaion = generalCardModel.munRaion;
            this.economicZone = generalCardModel.economicZone;
            this.city = generalCardModel.city;
            this.localityType = generalCardModel.localityType;
            this.locality = generalCardModel.locality;
            this.okrug = generalCardModel.okrug;
            this.raion = generalCardModel.raion;
            this.mikroraion = generalCardModel.mikroraion;
            this.section = generalCardModel.section;
            this.metroWalkName = generalCardModel.metroWalkName;
            this.metroWalkDistance = generalCardModel.metroWalkDistance;
            this.metroTransportName = generalCardModel.metroTransportName;
            this.metroTransportDistance = generalCardModel.metroTransportDistance;
            this.description = generalCardModel.description;
            this.dealType = generalCardModel.dealType;
            this.theCompositionOfTheTransferredRights = generalCardModel.theCompositionOfTheTransferredRights;
            this.dealComments = generalCardModel.dealComments;
            this.functionalPurpose = generalCardModel.functionalPurpose;
            this.specialty = generalCardModel.specialty;
            this.vatType = generalCardModel.vatType;
            this.price = generalCardModel.price;
            this.heatingType = generalCardModel.heatingType;
            this.analogNumber = generalCardModel.analogNumber;
            this.parseDate = generalCardModel.parseDate;
        }
        public GeneralCardModel(int id, int insideId, string phoneNumber, string cadNumber, string cardUrl, string publicationDate, string address, string lat, string lon, string subject, string munOkrug, string munRaion, string economicZone, string city, string localityType, string locality, string okrug, string raion, string mikroraion, string section, string metroWalkName, int metroWalkDistance, string metroTransportName, int metroTransportDistance, string description, string dealType, string theCompositionOfTheTransferredRights, string dealComments, string functionalPurpose, string specialty, string vatType, float price, string heatingType, int analogNumber, string parseDate)
        {
            Id = id;
            this.insideId = insideId;
            this.phoneNumber = phoneNumber;
            this.cadNumber = cadNumber;
            this.cardUrl = cardUrl;
            this.publicationDate = publicationDate;
            this.address = address;
            this.lat = lat;
            this.lon = lon;
            this.subject = subject;
            this.munOkrug = munOkrug;
            this.munRaion = munRaion;
            this.economicZone = economicZone;
            this.city = city;
            this.localityType = localityType;
            this.locality = locality;
            this.okrug = okrug;
            this.raion = raion;
            this.mikroraion = mikroraion;
            this.section = section;
            this.metroWalkName = metroWalkName;
            this.metroWalkDistance = metroWalkDistance;
            this.metroTransportName = metroTransportName;
            this.metroTransportDistance = metroTransportDistance;
            this.description = description;
            this.dealType = dealType;
            this.theCompositionOfTheTransferredRights = theCompositionOfTheTransferredRights;
            this.dealComments = dealComments;
            this.functionalPurpose = functionalPurpose;
            this.specialty = specialty;
            this.vatType = vatType;
            this.price = price;
            this.heatingType = heatingType;
            this.analogNumber = analogNumber;
            this.parseDate = parseDate;
        }
    }

    internal class OfficeCardModel : GeneralCardModel
    {
        public float totalArea { get; set; } //Площадь помещения, кв. м
        public string objectType { get; set; } //Тип объекта
        public string floorsCount { get; set; } //Этаж / общая этажность
        public float basementArea { get; set; } //Площадь подвала, кв. м
        public float areaGroundFloor { get; set; } //Площадь цоколя, кв. м
        public float areaPremisesHigherFirstFloor { get; set; } //Площадь помещений выше первого этажа, кв. м
        public float areaFirstFloor { get; set; } //Площадь первого этажа, кв. м
        public string parkingType { get; set; } //Тип парковки
        public string communalPaymentsInclude { get; set; } //Коммунальные платежи включены
        public float landArea { get; set; } //Площадь земли, кв. м
        public float prkingArea { get; set; } //Площадь паркинга, кв. м
        public float parkingElementArea { get; set; } //Площадь машиноместа, кв.м
        public string havingSeparateEntranceType { get; set; } //Тип входа
        public bool havingSeparateEntrance { get; set; } //Наличие отдельного входа
        public string ObjectLocationLine { get; set; } //Линия расположения объекта
        public string buildingClassType { get; set; } //Класс здания
        public string buildingType { get; set; } //Тип здания
        public float ceilingHeight { get; set; } //Высота потолков, м
        public string StateOfRepair { get; set; } //Состояние помещения
        public string layout { get; set; } //Планировка
        public string stateBuild { get; set; } //Состояние здания
        public string finishLevel { get; set; } //Уровень отделки
        public string entranceFromTheYard { get; set; } //Вход со двора
        public string entranceFromTheStreet { get; set; } //Вход с улицы
        public int buildYearsOld { get; set; } //Год постройки
        public int numberOfParkingSpaces { get; set; } //Количество парковочных мест, шт.

        public OfficeCardModel(GeneralCardModel generalCardModel, float totalArea, string objectType, string floorsCount, float basementArea, float areaGroundFloor, float areaPremisesHigherFirstFloor, float areaFirstFloor, string parkingType, string communalPaymentsInclude, float landArea, float prkingArea, float parkingElementArea, string havingSeparateEntranceType, bool havingSeparateEntrance, string objectLocationLine, string buildingClassType, string buildingType, float ceilingHeight, string stateOfRepair, string layout, string stateBuild, string finishLevel, string entranceFromTheYard, string entranceFromTheStreet, int buildYearsOld, int numberOfParkingSpaces)
        :base(generalCardModel)
        {
            this.totalArea = totalArea;
            this.objectType = objectType;
            this.floorsCount = floorsCount;
            this.basementArea = basementArea;
            this.areaGroundFloor = areaGroundFloor;
            this.areaPremisesHigherFirstFloor = areaPremisesHigherFirstFloor;
            this.areaFirstFloor = areaFirstFloor;
            this.parkingType = parkingType;
            this.communalPaymentsInclude = communalPaymentsInclude;
            this.landArea = landArea;
            this.prkingArea = prkingArea;
            this.parkingElementArea = parkingElementArea;
            this.havingSeparateEntranceType = havingSeparateEntranceType;
            this.havingSeparateEntrance = havingSeparateEntrance;
            ObjectLocationLine = objectLocationLine;
            this.buildingClassType = buildingClassType;
            this.buildingType = buildingType;
            this.ceilingHeight = ceilingHeight;
            StateOfRepair = stateOfRepair;
            this.layout = layout;
            this.stateBuild = stateBuild;
            this.finishLevel = finishLevel;
            this.entranceFromTheYard = entranceFromTheYard;
            this.entranceFromTheStreet = entranceFromTheStreet;
            this.buildYearsOld = buildYearsOld;
            this.numberOfParkingSpaces = numberOfParkingSpaces;
        }
    }

    internal class CianOfficeCardModelParser
    {

    }

    internal class GarageCardModel:GeneralCardModel
    {
        public float totalArea { get; set; } //Площадь помещения, кв. м
        public string isGarageBox { get; set; } //Гаражный бокс
        public int garageLevel { get; set; } //Уровень гаража
        public string garageType { get; set; } //Тип гаража
        public string garageMaterial { get; set; } //Материал гаража
        public string garageStatus { get; set; } //Статус гаража
        public float gateHeight { get; set; } //Высота ворот, м.
        public float garageHeight { get; set; } //Высота гаража, м.
        public string availabilityOfElectricity { get; set; } //Наличие электричества
        public string centralHeating { get; set; } //Наличие центрального отопления
        public string viewingHole { get; set; } //Наличие смотровой ямой
        public string twoParkingLots { get; set; } //Наличие двух парковочных мест
        public string basement { get; set; } //Наличие подвала
        public string presenceOfSecurity { get; set; } //Наличие охраны
        public string availabilityOfWaterSupplySewerage { get; set; } //Наличие водоснабжения
        public string presenceOfVideoSurveillance { get; set; } //Наличие видеонаблюдения
        public GarageCardModel(GeneralCardModel generalCardModel, float totalArea, string isGarageBox, int garageLevel, string garageType, string garageMaterial, string garageStatus, float gateHeight, float garageHeight, string availabilityOfElectricity, string centralHeating, string viewingHole, string twoParkingLots, string basement, string presenceOfSecurity, string availabilityOfWaterSupplySewerage, string presenceOfVideoSurveillance)
        :base(generalCardModel)
        {
            this.totalArea = totalArea;
            this.isGarageBox = isGarageBox;
            this.garageLevel = garageLevel;
            this.garageType = garageType;
            this.garageMaterial = garageMaterial;
            this.garageStatus = garageStatus;
            this.gateHeight = gateHeight;
            this.garageHeight = garageHeight;
            this.availabilityOfElectricity = availabilityOfElectricity;
            this.centralHeating = centralHeating;
            this.viewingHole = viewingHole;
            this.twoParkingLots = twoParkingLots;
            this.basement = basement;
            this.presenceOfSecurity = presenceOfSecurity;
            this.availabilityOfWaterSupplySewerage = availabilityOfWaterSupplySewerage;
            this.presenceOfVideoSurveillance = presenceOfVideoSurveillance;
        }
    }

    internal class CianGarageCardModelParser
    {

    }

    internal class LandCardModel : GeneralCardModel
    {
        public float landArea { get; set; } //Площадь земли, кв. м
        public string landCategory { get; set; } //Категория земель
        public string permittedUse { get; set; } //ВРИ
        public string distanceToMotorway { get; set; } //Расположение относительно автомагистрали
        public string availabilityOfFreeAccessToTheSite { get; set; } //Наличие свободного подъезда к участку
        public float totalBuildingArea { get; set; } //Площадь зданий на участке, кв.м.
        public string presenceOfBuildingsStructuresForDemolition { get; set; } //Наличие зданий/строений под снос
        public string haveTrainStation { get; set; } //Наличие ж/д на участке
        public string availabilityOfGasSupply { get; set; } //Наличие газоснабжения
        public string availabilityOfPowerSupply { get; set; } //Наличие электроснабжения
        public string availabilityOfWaterSupplySewerage { get; set; } //Наличие водоснабжения, канализации
        public string buildingPermit { get; set; } //Наличие ИРД (разрешение на строительство)
        public string buildingPermitComments { get; set; } //Комментарии (Наличие ИРД)
        public string territoryPlanningProject { get; set; } //Проект планировки территории
        public string initialPermitDocumentation { get; set; } //Исходно-разрешительная документация
        public string parkingType { get; set; } //Тип парковки

        public LandCardModel(GeneralCardModel generalCardModel, float landArea, string landCategory, string permittedUse, string distanceToMotorway, string availabilityOfFreeAccessToTheSite, float totalBuildingArea, string presenceOfBuildingsStructuresForDemolition, string haveTrainStation, string availabilityOfGasSupply, string availabilityOfPowerSupply, string availabilityOfWaterSupplySewerage, string buildingPermit, string buildingPermitComments, string territoryPlanningProject, string initialPermitDocumentation, string parkingType)
        :base(generalCardModel)
        {
            this.landArea = landArea;
            this.landCategory = landCategory;
            this.permittedUse = permittedUse;
            this.distanceToMotorway = distanceToMotorway;
            this.availabilityOfFreeAccessToTheSite = availabilityOfFreeAccessToTheSite;
            this.totalBuildingArea = totalBuildingArea;
            this.presenceOfBuildingsStructuresForDemolition = presenceOfBuildingsStructuresForDemolition;
            this.haveTrainStation = haveTrainStation;
            this.availabilityOfGasSupply = availabilityOfGasSupply;
            this.availabilityOfPowerSupply = availabilityOfPowerSupply;
            this.availabilityOfWaterSupplySewerage = availabilityOfWaterSupplySewerage;
            this.buildingPermit = buildingPermit;
            this.buildingPermitComments = buildingPermitComments;
            this.territoryPlanningProject = territoryPlanningProject;
            this.initialPermitDocumentation = initialPermitDocumentation;
            this.parkingType = parkingType;
        }
    }

    internal class CianLandCardModelParser
    {

    }
}
