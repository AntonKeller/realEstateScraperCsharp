using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightExtraSharp;
using Microsoft.Playwright;
using System.Windows.Forms;

namespace realEstateScraperCsharp.Modules
{
    //| Реализовать для классов
    class Field<T>
    {
        public T Value { get; set; }
        public string Description { get; set; }
    }

    class GeneralFields
    {
        public int? Id { get; set; } //Уникальный id
        public int?  InsideId {get;set;} //Внутренний id (на сайте при наличии)
        public string PhoneNumber { get;set; } //Номер телефона
        public string CadNumber { get;set; } //Кадастровый номер
        public string CardUrl { get;set; } //Url карточки (предложения)
        public string PublicationDate { get;set; } //Дата публикации
        public string Address { get;set; } //Полный адрес местонахождения
        public string Lat { get;set; } //Координата широта
        public string Lon { get;set; } //Координата долгота
        public string Subject { get;set; } //Субъект федерации
        public string MunOkrug { get;set; } //Муниципальный округ
        public string MunRaion { get;set; } //Муниципальный район
        public string EconomicZone { get;set; } //Муниципальный район
        public string City { get;set; } //Город
        public string LocalityType { get;set; } //Тип поселения (при наличии, для Москвы ...)
        public string Locality { get;set; } //Наименование поселения (при наличии, для Москвы ...)
        public string Okrug { get;set; } //Административный округ
        public string Raion { get;set; } //Административный район
        public string Mikroraion { get;set; } //Микрорайон
        public string Section { get;set; } //Квартал
        public string MetroWalkName { get;set; } //Ближайшая станция метро (пешком)
        public int? MetroWalkDistance { get;set; } //Удаленность от метро (мин. пешком)
        public string MetroTransportName { get;set; } //Ближайшая станция метро (транспорт)
        public int? MetroTransportDistance { get;set; } //Удаленность от метро (мин. транспорт)
        public string Description { get;set; } //Описание
        public string DealType { get;set; } //Тип сделки
        public string TransferredRights { get; set; } //Состав передаваемых прав
        public string DealComments { get; set; } //Коментарии к сделке
        public string FunctionalPurpose { get;set; } //Функциональное назначение
        public string Specialty { get;set; } //Варианты использования
        public string VatType { get;set; } //НДС
        public float? Price { get;set; } //Цена предложения
        public string HeatingType { get;set; } //Тип отопления
        public int? AnalogNumber { get;set; } //Номер аналога
        public DateTime ParseDate { get;set; } //Дата парсинга
        public GeneralFields(CompleteFields fields)
        {
            this.Id = fields.Id;
            this.InsideId = fields.InsideId;
            this.PhoneNumber = fields.PhoneNumber;
            this.CadNumber = fields.CadNumber;
            this.CardUrl = fields.CardUrl;
            this.PublicationDate = fields.PublicationDate;
            this.Address = fields.Address;
            this.Lat = fields.Lat;
            this.Lon = fields.Lon;
            this.Subject = fields.Subject;
            this.MunOkrug = fields.MunOkrug;
            this.MunRaion = fields.MunRaion;
            this.EconomicZone = fields.EconomicZone;
            this.City = fields.City;
            this.LocalityType = fields.LocalityType;
            this.Locality = fields.Locality;
            this.Okrug = fields.Okrug;
            this.Raion = fields.Raion;
            this.Mikroraion = fields.Mikroraion;
            this.Section = fields.Section;
            this.MetroWalkName = fields.MetroWalkName;
            this.MetroWalkDistance = fields.MetroWalkDistance;
            this.MetroTransportName = fields.MetroTransportName;
            this.MetroTransportDistance = fields.MetroTransportDistance;
            this.Description = fields.Description;
            this.DealType = fields.DealType;
            this.TransferredRights = fields.TransferredRights;
            this.DealComments = fields.DealComments;
            this.FunctionalPurpose = fields.FunctionalPurpose;
            this.Specialty = fields.Specialty;
            this.VatType = fields.VatType;
            this.Price = fields.Price;
            this.HeatingType = fields.HeatingType;
            this.AnalogNumber = fields.AnalogNumber;
            this.ParseDate = fields.ParseDate;
        }
        public GeneralFields(GeneralFields fields)
        {
            this.Id = fields.Id;
            this.InsideId = fields.InsideId;
            this.PhoneNumber = fields.PhoneNumber;
            this.CadNumber = fields.CadNumber;
            this.CardUrl = fields.CardUrl;
            this.PublicationDate = fields.PublicationDate;
            this.Address = fields.Address;
            this.Lat = fields.Lat;
            this.Lon = fields.Lon;
            this.Subject = fields.Subject;
            this.MunOkrug = fields.MunOkrug;
            this.MunRaion = fields.MunRaion;
            this.EconomicZone = fields.EconomicZone;
            this.City = fields.City;
            this.LocalityType = fields.LocalityType;
            this.Locality = fields.Locality;
            this.Okrug = fields.Okrug;
            this.Raion = fields.Raion;
            this.Mikroraion = fields.Mikroraion;
            this.Section = fields.Section;
            this.MetroWalkName = fields.MetroWalkName;
            this.MetroWalkDistance = fields.MetroWalkDistance;
            this.MetroTransportName = fields.MetroTransportName;
            this.MetroTransportDistance = fields.MetroTransportDistance;
            this.Description = fields.Description;
            this.DealType = fields.DealType;
            this.TransferredRights = fields.TransferredRights;
            this.DealComments = fields.DealComments;
            this.FunctionalPurpose = fields.FunctionalPurpose;
            this.Specialty = fields.Specialty;
            this.VatType = fields.VatType;
            this.Price = fields.Price;
            this.HeatingType = fields.HeatingType;
            this.AnalogNumber = fields.AnalogNumber;
            this.ParseDate = fields.ParseDate;
        }
        public GeneralFields(int id, int insideId, string phoneNumber, string cadNumber, string cardUrl, string publicationDate, string address, string lat, string lon, string subject, string munOkrug, string munRaion, string economicZone, string city, string localityType, string locality, string okrug, string raion, string mikroraion, string section, string metroWalkName, int metroWalkDistance, string metroTransportName, int metroTransportDistance, string description, string dealType, string theCompositionOfTheTransferredRights, string dealComments, string functionalPurpose, string specialty, string vatType, float price, string heatingType, int analogNumber, DateTime parseDate)
        {
            Id = id;
            this.InsideId = insideId;
            this.PhoneNumber = phoneNumber;
            this.CadNumber = cadNumber;
            this.CardUrl = cardUrl;
            this.PublicationDate = publicationDate;
            this.Address = address;
            this.Lat = lat;
            this.Lon = lon;
            this.Subject = subject;
            this.MunOkrug = munOkrug;
            this.MunRaion = munRaion;
            this.EconomicZone = economicZone;
            this.City = city;
            this.LocalityType = localityType;
            this.Locality = locality;
            this.Okrug = okrug;
            this.Raion = raion;
            this.Mikroraion = mikroraion;
            this.Section = section;
            this.MetroWalkName = metroWalkName;
            this.MetroWalkDistance = metroWalkDistance;
            this.MetroTransportName = metroTransportName;
            this.MetroTransportDistance = metroTransportDistance;
            this.Description = description;
            this.DealType = dealType;
            this.TransferredRights = theCompositionOfTheTransferredRights;
            this.DealComments = dealComments;
            this.FunctionalPurpose = functionalPurpose;
            this.Specialty = specialty;
            this.VatType = vatType;
            this.Price = price;
            this.HeatingType = heatingType;
            this.AnalogNumber = analogNumber;
            this.ParseDate = parseDate;
        }
    }

    class OfficeFields
    {
        public float? TotalArea { get; set; } //Площадь помещения, кв. м
        public string ObjectType { get; set; } //Тип объекта
        public string FloorsCount { get; set; } //Этаж / общая этажность
        public float? BasementArea { get; set; } //Площадь подвала, кв. м
        public float? AreaGroundFloor { get; set; } //Площадь цоколя, кв. м
        public float? AreaPremisesHigherFirstFloor { get; set; } //Площадь помещений выше первого этажа, кв. м
        public float? AreaFirstFloor { get; set; } //Площадь первого этажа, кв. м
        public string ParkingType { get; set; } //Тип парковки
        public string CommunalPaymentsInclude { get; set; } //Коммунальные платежи включены
        public float? LandArea { get; set; } //Площадь земли, кв. м
        public float? PrkingArea { get; set; } //Площадь паркинга, кв. м
        public float? ParkingElementArea { get; set; } //Площадь машиноместа, кв.м
        public string HavingSeparateEntranceType { get; set; } //Тип входа
        public bool? HavingSeparateEntrance { get; set; } //Наличие отдельного входа
        public string ObjectLocationLine { get; set; } //Линия расположения объекта
        public string BuildingClassType { get; set; } //Класс здания
        public string BuildType { get; set; } //Тип здания
        public float? CeilingHeight { get; set; } //Высота потолков, м
        public string StateOfRepair { get; set; } //Состояние помещения
        public string Layout { get; set; } //Планировка
        public string StateBuild { get; set; } //Состояние здания
        public string FinishLevel { get; set; } //Уровень отделки
        public string EntranceFromTheYard { get; set; } //Вход со двора
        public string EntranceFromTheStreet { get; set; } //Вход с улицы
        public int? BuildYearsOld { get; set; } //Год постройки
        public int? NumberOfParkingSpaces { get; set; } //Количество парковочных мест, шт.
        public OfficeFields(CompleteFields fields)
        {
            this.TotalArea = fields.TotalArea;
            this.ObjectType = fields.ObjectType;
            this.FloorsCount = fields.FloorsCount;
            this.BasementArea = fields.BasementArea;
            this.AreaGroundFloor = fields.AreaGroundFloor;
            this.AreaPremisesHigherFirstFloor = fields.AreaPremisesHigherFirstFloor;
            this.AreaFirstFloor = fields.AreaFirstFloor;
            this.ParkingType = fields.ParkingType;
            this.CommunalPaymentsInclude = fields.CommunalPaymentsInclude;
            this.LandArea = fields.LandArea;
            this.PrkingArea = fields.PrkingArea;
            this.ParkingElementArea = fields.ParkingElementArea;
            this.HavingSeparateEntranceType = fields.HavingSeparateEntranceType;
            this.HavingSeparateEntrance = fields.HavingSeparateEntrance;
            this.ObjectLocationLine = fields.ObjectLocationLine;
            this.BuildingClassType = fields.BuildingClassType;
            this.BuildType = fields.BuildType;
            this.CeilingHeight = fields.CeilingHeight;
            this.StateOfRepair = fields.StateOfRepair;
            this.Layout = fields.Layout;
            this.StateBuild = fields.StateBuild;
            this.FinishLevel = fields.FinishLevel;
            this.EntranceFromTheYard = fields.EntranceFromTheYard;
            this.EntranceFromTheStreet = fields.EntranceFromTheStreet;
            this.BuildYearsOld = fields.BuildYearsOld;
            this.NumberOfParkingSpaces = fields.NumberOfParkingSpaces;
        }
        public OfficeFields(OfficeFields fields)
        {
            this.TotalArea = fields.TotalArea;
            this.ObjectType = fields.ObjectType;
            this.FloorsCount = fields.FloorsCount;
            this.BasementArea = fields.BasementArea;
            this.AreaGroundFloor = fields.AreaGroundFloor;
            this.AreaPremisesHigherFirstFloor = fields.AreaPremisesHigherFirstFloor;
            this.AreaFirstFloor = fields.AreaFirstFloor;
            this.ParkingType = fields.ParkingType;
            this.CommunalPaymentsInclude = fields.CommunalPaymentsInclude;
            this.LandArea = fields.LandArea;
            this.PrkingArea = fields.PrkingArea;
            this.ParkingElementArea = fields.ParkingElementArea;
            this.HavingSeparateEntranceType = fields.HavingSeparateEntranceType;
            this.HavingSeparateEntrance = fields.HavingSeparateEntrance;
            this.ObjectLocationLine = fields.ObjectLocationLine;
            this.BuildingClassType = fields.BuildingClassType;
            this.BuildType = fields.BuildType;
            this.CeilingHeight = fields.CeilingHeight;
            this.StateOfRepair = fields.StateOfRepair;
            this.Layout = fields.Layout;
            this.StateBuild = fields.StateBuild;
            this.FinishLevel = fields.FinishLevel;
            this.EntranceFromTheYard = fields.EntranceFromTheYard;
            this.EntranceFromTheStreet = fields.EntranceFromTheStreet;
            this.BuildYearsOld = fields.BuildYearsOld;
            this.NumberOfParkingSpaces = fields.NumberOfParkingSpaces;
        }
        public OfficeFields(
            float totalArea, string objectType, string floorsCount, float basementArea,
            float areaGroundFloor, float areaPremisesHigherFirstFloor, float areaFirstFloor,
            string parkingType, string communalPaymentsInclude, float landArea,
            float prkingArea, float parkingElementArea, string havingSeparateEntranceType,
            bool havingSeparateEntrance, string objectLocationLine, string buildingClassType,
            string buildType, float ceilingHeight, string stateOfRepair, string layout,
            string stateBuild, string finishLevel, string entranceFromTheYard,
            string entranceFromTheStreet, int buildYearsOld, int numberOfParkingSpaces
        )
        {
            this.TotalArea = totalArea;
            this.ObjectType = objectType;
            this.FloorsCount = floorsCount;
            this.BasementArea = basementArea;
            this.AreaGroundFloor = areaGroundFloor;
            this.AreaPremisesHigherFirstFloor = areaPremisesHigherFirstFloor;
            this.AreaFirstFloor = areaFirstFloor;
            this.ParkingType = parkingType;
            this.CommunalPaymentsInclude = communalPaymentsInclude;
            this.LandArea = landArea;
            this.PrkingArea = prkingArea;
            this.ParkingElementArea = parkingElementArea;
            this.HavingSeparateEntranceType = havingSeparateEntranceType;
            this.HavingSeparateEntrance = havingSeparateEntrance;
            this.ObjectLocationLine = objectLocationLine;
            this.BuildingClassType = buildingClassType;
            this.BuildType = buildType;
            this.CeilingHeight = ceilingHeight;
            this.StateOfRepair = stateOfRepair;
            this.Layout = layout;
            this.StateBuild = stateBuild;
            this.FinishLevel = finishLevel;
            this.EntranceFromTheYard = entranceFromTheYard;
            this.EntranceFromTheStreet = entranceFromTheStreet;
            this.BuildYearsOld = buildYearsOld;
            this.NumberOfParkingSpaces = numberOfParkingSpaces;
        }
    }

    class GarageFields
    {
        public float? TotalArea { get; set; } //Площадь помещения, кв. м
        public string IsGarageBox { get; set; } //Гаражный бокс
        public int? GarageLevel { get; set; } //Уровень гаража
        public string GarageType { get; set; } //Тип гаража
        public string GarageStatus { get; set; } //Статус гаража
        public float? GateHeight { get; set; } //Высота ворот, м.
        public float? GarageHeight { get; set; } //Высота гаража, м.
        public string AvailabilityOfElectricity { get; set; } //Наличие электричества
        public string CentralHeating { get; set; } //Наличие центрального отопления
        public string ViewingHole { get; set; } //Наличие смотровой ямой
        public string TwoParkingLots { get; set; } //Наличие двух парковочных мест
        public string Basement { get; set; } //Наличие подвала
        public string PresenceOfSecurity { get; set; } //Наличие охраны
        public string AvailabilityOfWaterSupplySewerage { get; set; } //Наличие водоснабжения
        public string PresenceOfVideoSurveillance { get; set; } //Наличие видеонаблюдения
        public GarageFields(CompleteFields fields)
        {
            this.TotalArea = fields.TotalArea;
            this.IsGarageBox = fields.IsGarageBox;
            this.GarageLevel = fields.GarageLevel;
            this.GarageType = fields.GarageType;
            this.GarageStatus = fields.GarageStatus;
            this.GateHeight = fields.GateHeight;
            this.GarageHeight = fields.GarageHeight;
            this.AvailabilityOfElectricity = fields.AvailabilityOfElectricity;
            this.CentralHeating = fields.CentralHeating;
            this.ViewingHole = fields.ViewingHole;
            this.TwoParkingLots = fields.TwoParkingLots;
            this.Basement = fields.Basement;
            this.PresenceOfSecurity = fields.PresenceOfSecurity;
            this.AvailabilityOfWaterSupplySewerage = fields.AvailabilityOfWaterSupplySewerage;
            this.PresenceOfVideoSurveillance = fields.PresenceOfVideoSurveillance;
        }
        public GarageFields(GarageFields fields)
        {
            this.TotalArea = fields.TotalArea;
            this.IsGarageBox = fields.IsGarageBox;
            this.GarageLevel = fields.GarageLevel;
            this.GarageType = fields.GarageType;
            this.GarageStatus = fields.GarageStatus;
            this.GateHeight = fields.GateHeight;
            this.GarageHeight = fields.GarageHeight;
            this.AvailabilityOfElectricity = fields.AvailabilityOfElectricity;
            this.CentralHeating = fields.CentralHeating;
            this.ViewingHole = fields.ViewingHole;
            this.TwoParkingLots = fields.TwoParkingLots;
            this.Basement = fields.Basement;
            this.PresenceOfSecurity = fields.PresenceOfSecurity;
            this.AvailabilityOfWaterSupplySewerage = fields.AvailabilityOfWaterSupplySewerage;
            this.PresenceOfVideoSurveillance = fields.PresenceOfVideoSurveillance;
        }
        public GarageFields(
            float totalArea, string isGarageBox, int garageLevel, string garageType,
            string garageStatus, float gateHeight, float garageHeight,
            string availabilityOfElectricity, string centralHeating, string viewingHole,
            string twoParkingLots, string basement, string presenceOfSecurity,
            string availabilityOfWaterSupplySewerage, string presenceOfVideoSurveillance
        )
        {
            this.TotalArea = totalArea;
            this.IsGarageBox = isGarageBox;
            this.GarageLevel = garageLevel;
            this.GarageType = garageType;
            this.GarageStatus = garageStatus;
            this.GateHeight = gateHeight;
            this.GarageHeight = garageHeight;
            this.AvailabilityOfElectricity = availabilityOfElectricity;
            this.CentralHeating = centralHeating;
            this.ViewingHole = viewingHole;
            this.TwoParkingLots = twoParkingLots;
            this.Basement = basement;
            this.PresenceOfSecurity = presenceOfSecurity;
            this.AvailabilityOfWaterSupplySewerage = availabilityOfWaterSupplySewerage;
            this.PresenceOfVideoSurveillance = presenceOfVideoSurveillance;
        }
    }

    class LandFields
    {
        public float? LandArea { get; set; } //Площадь земли, кв. м
        public string LandCategory { get; set; } //Категория земель
        public string PermittedUse { get; set; } //ВРИ
        public string DistanceToMotorway { get; set; } //Расположение относительно автомагистрали
        public string AvailabilityOfFreeAccessToTheSite { get; set; } //Наличие свободного подъезда к участку
        public float? TotalBuildingArea { get; set; } //Площадь зданий на участке, кв.м.
        public string PresenceOfBuildingsStructuresForDemolition { get; set; } //Наличие зданий/строений под снос
        public string HaveTrainStation { get; set; } //Наличие ж/д на участке
        public string AvailabilityOfGasSupply { get; set; } //Наличие газоснабжения
        public string AvailabilityOfPowerSupply { get; set; } //Наличие электроснабжения
        public string AvailabilityOfWaterSupplySewerage { get; set; } //Наличие водоснабжения, канализации
        public string BuildingPermit { get; set; } //Наличие ИРД (разрешение на строительство)
        public string BuildingPermitComments { get; set; } //Комментарии (Наличие ИРД)
        public string TerritoryPlanningProject { get; set; } //Проект планировки территории
        public string InitialPermitDocumentation { get; set; } //Исходно-разрешительная документация
        public string ParkingType { get; set; } //Тип парковки
        public LandFields(CompleteFields fields)
        {
            this.LandArea = fields.LandArea;
            this.LandCategory = fields.LandCategory;
            this.PermittedUse = fields.PermittedUse;
            this.DistanceToMotorway = fields.DistanceToMotorway;
            this.AvailabilityOfFreeAccessToTheSite = fields.AvailabilityOfFreeAccessToTheSite;
            this.TotalBuildingArea = fields.TotalBuildingArea;
            this.PresenceOfBuildingsStructuresForDemolition = fields.PresenceOfBuildingsStructuresForDemolition;
            this.HaveTrainStation = fields.HaveTrainStation;
            this.AvailabilityOfGasSupply = fields.AvailabilityOfGasSupply;
            this.AvailabilityOfPowerSupply = fields.AvailabilityOfPowerSupply;
            this.AvailabilityOfWaterSupplySewerage = fields.AvailabilityOfWaterSupplySewerage;
            this.BuildingPermit = fields.BuildingPermit;
            this.BuildingPermitComments = fields.BuildingPermitComments;
            this.TerritoryPlanningProject = fields.TerritoryPlanningProject;
            this.InitialPermitDocumentation = fields.InitialPermitDocumentation;
            this.ParkingType = fields.ParkingType;
        }
        public LandFields(LandFields fields)
        {
            this.LandArea = fields.LandArea;
            this.LandCategory = fields.LandCategory;
            this.PermittedUse = fields.PermittedUse;
            this.DistanceToMotorway = fields.DistanceToMotorway;
            this.AvailabilityOfFreeAccessToTheSite = fields.AvailabilityOfFreeAccessToTheSite;
            this.TotalBuildingArea = fields.TotalBuildingArea;
            this.PresenceOfBuildingsStructuresForDemolition = fields.PresenceOfBuildingsStructuresForDemolition;
            this.HaveTrainStation = fields.HaveTrainStation;
            this.AvailabilityOfGasSupply = fields.AvailabilityOfGasSupply;
            this.AvailabilityOfPowerSupply = fields.AvailabilityOfPowerSupply;
            this.AvailabilityOfWaterSupplySewerage = fields.AvailabilityOfWaterSupplySewerage;
            this.BuildingPermit = fields.BuildingPermit;
            this.BuildingPermitComments = fields.BuildingPermitComments;
            this.TerritoryPlanningProject = fields.TerritoryPlanningProject;
            this.InitialPermitDocumentation = fields.InitialPermitDocumentation;
            this.ParkingType = fields.ParkingType;
        }
        public LandFields(
            float landArea, string landCategory, string permittedUse, string distanceToMotorway,
            string availabilityOfFreeAccessToTheSite, float totalBuildingArea, 
            string presenceOfBuildingsStructuresForDemolition, string haveTrainStation,
            string availabilityOfGasSupply, string availabilityOfPowerSupply,
            string availabilityOfWaterSupplySewerage, string buildingPermit,
            string buildingPermitComments, string territoryPlanningProject,
            string initialPermitDocumentation, string parkingType
        )
        {
            this.LandArea = landArea;
            this.LandCategory = landCategory;
            this.PermittedUse = permittedUse;
            this.DistanceToMotorway = distanceToMotorway;
            this.AvailabilityOfFreeAccessToTheSite = availabilityOfFreeAccessToTheSite;
            this.TotalBuildingArea = totalBuildingArea;
            this.PresenceOfBuildingsStructuresForDemolition = presenceOfBuildingsStructuresForDemolition;
            this.HaveTrainStation = haveTrainStation;
            this.AvailabilityOfGasSupply = availabilityOfGasSupply;
            this.AvailabilityOfPowerSupply = availabilityOfPowerSupply;
            this.AvailabilityOfWaterSupplySewerage = availabilityOfWaterSupplySewerage;
            this.BuildingPermit = buildingPermit;
            this.BuildingPermitComments = buildingPermitComments;
            this.TerritoryPlanningProject = territoryPlanningProject;
            this.InitialPermitDocumentation = initialPermitDocumentation;
            this.ParkingType = parkingType;
        }
    }

    internal class OfficeCardModel
    {
        public GeneralFields General { get; set; }
        public OfficeFields Office { get; set; }

        public OfficeCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public OfficeCardModel(OfficeFields office)
        {
            this.Office = new OfficeFields(office);
        }
        public OfficeCardModel(GeneralFields general, OfficeFields office)
        {
            this.General = new GeneralFields(general);
            this.Office = new OfficeFields(office);
        }
    }

    internal class GarageCardModel
    {
        public GeneralFields General { get; set; }
        public GarageFields Garage { get; set; }
        
        //| ...........................................
        public GarageCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public GarageCardModel(GarageFields garage)
        {
            this.Garage = new GarageFields(garage);
        }
        public GarageCardModel(GeneralFields general, GarageFields garage)
        {
            this.General = new GeneralFields(general);
            this.Garage = new GarageFields(garage);
        }
    }

    internal class LandCardModel
    {
        public GeneralFields General { get; set; }
        public LandFields Land { get; set; }
        public LandCardModel(GeneralFields general)
        {
            this.General = new GeneralFields(general);
        }
        public LandCardModel(LandFields land)
        {
            this.Land = new LandFields(land);
        }
        public LandCardModel(GeneralFields general, LandFields land)
        {
            this.General = new GeneralFields(general);
            this.Land = new LandFields(land);
        }
    }

    internal class CompleteFields
    {
        public int? Id { get; set; } //Уникальный id
        public int? InsideId { get; set; } //Внутренний id (на сайте при наличии)
        public string PhoneNumber { get; set; } //Номер телефона
        public string CadNumber { get; set; } //Кадастровый номер
        public string CardUrl { get; set; } //Url карточки (предложения)
        public string PublicationDate { get; set; } //Дата публикации
        public string Address { get; set; } //Полный адрес местонахождения
        public string Lat { get; set; } //Координата широта
        public string Lon { get; set; } //Координата долгота
        public string Subject { get; set; } //Субъект федерации
        public string MunOkrug { get; set; } //Муниципальный округ
        public string MunRaion { get; set; } //Муниципальный район
        public string EconomicZone { get; set; } //Муниципальный район
        public string City { get; set; } //Город
        public string LocalityType { get; set; } //Тип поселения (при наличии, для Москвы ...)
        public string Locality { get; set; } //Наименование поселения (при наличии, для Москвы ...)
        public string Okrug { get; set; } //Административный округ
        public string Raion { get; set; } //Административный район
        public string Mikroraion { get; set; } //Микрорайон
        public string Section { get; set; } //Квартал
        public string MetroWalkName { get; set; } //Ближайшая станция метро (пешком)
        public int? MetroWalkDistance { get; set; } //Удаленность от метро (мин. пешком)
        public string MetroTransportName { get; set; } //Ближайшая станция метро (транспорт)
        public int? MetroTransportDistance { get; set; } //Удаленность от метро (мин. транспорт)
        public string Description { get; set; } //Описание
        public string DealType { get; set; } //Тип сделки
        public string TransferredRights { get; set; } //Состав передаваемых прав
        public string DealComments { get; set; } //Коментарии к сделке
        public string FunctionalPurpose { get; set; } //Функциональное назначение
        public string Specialty { get; set; } //Варианты использования
        public string VatType { get; set; } //НДС
        public float? Price { get; set; } //Цена предложения
        public string HeatingType { get; set; } //Тип отопления
        public int? AnalogNumber { get; set; } //Номер аналога
        public DateTime ParseDate { get; set; } //Дата парсинга
        public float? TotalArea { get; set; } //Площадь помещения, кв. м
        public string ObjectType { get; set; } //Тип объекта
        public string FloorsCount { get; set; } //Этаж / общая этажность
        public float? BasementArea { get; set; } //Площадь подвала, кв. м
        public float? AreaGroundFloor { get; set; } //Площадь цоколя, кв. м
        public float? AreaPremisesHigherFirstFloor { get; set; } //Площадь помещений выше первого этажа, кв. м
        public float? AreaFirstFloor { get; set; } //Площадь первого этажа, кв. м
        public string ParkingType { get; set; } //Тип парковки
        public string CommunalPaymentsInclude { get; set; } //Коммунальные платежи включены
        public float? LandArea { get; set; } //Площадь земли, кв. м
        public float? PrkingArea { get; set; } //Площадь паркинга, кв. м
        public float? ParkingElementArea { get; set; } //Площадь машиноместа, кв.м
        public string HavingSeparateEntranceType { get; set; } //Тип входа
        public bool? HavingSeparateEntrance { get; set; } //Наличие отдельного входа
        public string ObjectLocationLine { get; set; } //Линия расположения объекта
        public string BuildingClassType { get; set; } //Класс здания
        public string BuildType { get; set; } //Тип здания
        public string BuildMaterial { get; set; } //Материал здания
        public float? CeilingHeight { get; set; } //Высота потолков, м
        public string StateOfRepair { get; set; } //Состояние помещения
        public string Layout { get; set; } //Планировка
        public string StateBuild { get; set; } //Состояние здания
        public string FinishLevel { get; set; } //Уровень отделки
        public string EntranceFromTheYard { get; set; } //Вход со двора
        public string EntranceFromTheStreet { get; set; } //Вход с улицы
        public int? BuildYearsOld { get; set; } //Год постройки
        public int? NumberOfParkingSpaces { get; set; } //Количество парковочных мест, шт.
        public string IsGarageBox { get; set; } //Гаражный бокс
        public int? GarageLevel { get; set; } //Уровень гаража
        public string GarageType { get; set; } //Тип гаража
        public string GarageStatus { get; set; } //Статус гаража
        public float? GateHeight { get; set; } //Высота ворот, м.
        public float? GarageHeight { get; set; } //Высота гаража, м.
        public string AvailabilityOfElectricity { get; set; } //Наличие электричества
        public string CentralHeating { get; set; } //Наличие центрального отопления
        public string ViewingHole { get; set; } //Наличие смотровой ямой
        public string TwoParkingLots { get; set; } //Наличие двух парковочных мест
        public string Basement { get; set; } //Наличие подвала
        public string PresenceOfSecurity { get; set; } //Наличие охраны
        public string AvailabilityOfWaterSupplySewerage { get; set; } //Наличие водоснабжения
        public string PresenceOfVideoSurveillance { get; set; } //Наличие видеонаблюдения
        public string LandCategory { get; set; } //Категория земель
        public string PermittedUse { get; set; } //ВРИ
        public string DistanceToMotorway { get; set; } //Расположение относительно автомагистрали
        public string AvailabilityOfFreeAccessToTheSite { get; set; } //Наличие свободного подъезда к участку
        public float? TotalBuildingArea { get; set; } //Площадь зданий на участке, кв.м.
        public string PresenceOfBuildingsStructuresForDemolition { get; set; } //Наличие зданий/строений под снос
        public string HaveTrainStation { get; set; } //Наличие ж/д на участке
        public string AvailabilityOfGasSupply { get; set; } //Наличие газоснабжения
        public string AvailabilityOfPowerSupply { get; set; } //Наличие электроснабжения
        public string BuildingPermit { get; set; } //Наличие ИРД (разрешение на строительство)
        public string BuildingPermitComments { get; set; } //Комментарии (Наличие ИРД)
        public string TerritoryPlanningProject { get; set; } //Проект планировки территории
        public string InitialPermitDocumentation { get; set; } //Исходно-разрешительная документация
        public CompleteFields() { }
        public CompleteFields(CompleteFields data)
        {
            this.Id = data.Id;
            this.InsideId = data.InsideId;
            this.PhoneNumber = data.PhoneNumber;
            this.CadNumber = data.CadNumber;
            this.CardUrl = data.CardUrl;
            this.PublicationDate = data.PublicationDate;
            this.Address = data.Address;
            this.Lat = data.Lat;
            this.Lon = data.Lon;
            this.Subject = data.Subject;
            this.MunOkrug = data.MunOkrug;
            this.MunRaion = data.MunRaion;
            this.EconomicZone = data.EconomicZone;
            this.City = data.City;
            this.LocalityType = data.LocalityType;
            this.Locality = data.Locality;
            this.Okrug = data.Okrug;
            this.Raion = data.Raion;
            this.Mikroraion = data.Mikroraion;
            this.Section = data.Section;
            this.MetroWalkName = data.MetroWalkName;
            this.MetroWalkDistance = data.MetroWalkDistance;
            this.MetroTransportName = data.MetroTransportName;
            this.MetroTransportDistance = data.MetroTransportDistance;
            this.Description = data.Description;
            this.DealType = data.DealType;
            this.TransferredRights = data.TransferredRights;
            this.DealComments = data.DealComments;
            this.FunctionalPurpose = data.FunctionalPurpose;
            this.Specialty = data.Specialty;
            this.VatType = data.VatType;
            this.Price = data.Price;
            this.HeatingType = data.HeatingType;
            this.AnalogNumber = data.AnalogNumber;
            this.ParseDate = data.ParseDate;
            this.TotalArea = data.TotalArea;
            this.ObjectType = data.ObjectType;
            this.FloorsCount = data.FloorsCount;
            this.BasementArea = data.BasementArea;
            this.AreaGroundFloor = data.AreaGroundFloor;
            this.AreaPremisesHigherFirstFloor = data.AreaPremisesHigherFirstFloor;
            this.AreaFirstFloor = data.AreaFirstFloor;
            this.ParkingType = data.ParkingType;
            this.CommunalPaymentsInclude = data.CommunalPaymentsInclude;
            this.LandArea = data.LandArea;
            this.PrkingArea = data.PrkingArea;
            this.ParkingElementArea = data.ParkingElementArea;
            this.HavingSeparateEntranceType = data.HavingSeparateEntranceType;
            this.HavingSeparateEntrance = data.HavingSeparateEntrance;
            this.ObjectLocationLine = data.ObjectLocationLine;
            this.BuildingClassType = data.BuildingClassType;
            this.BuildType = data.BuildType;
            this.BuildMaterial = data.BuildMaterial;
            this.CeilingHeight = data.CeilingHeight;
            this.StateOfRepair = data.StateOfRepair;
            this.Layout = data.Layout;
            this.StateBuild = data.StateBuild;
            this.FinishLevel = data.FinishLevel;
            this.EntranceFromTheYard = data.EntranceFromTheYard;
            this.EntranceFromTheStreet = data.EntranceFromTheStreet;
            this.BuildYearsOld = data.BuildYearsOld;
            this.NumberOfParkingSpaces = data.NumberOfParkingSpaces;
            this.IsGarageBox = data.IsGarageBox;
            this.GarageLevel = data.GarageLevel;
            this.GarageType = data.GarageType;
            this.GarageStatus = data.GarageStatus;
            this.GateHeight = data.GateHeight;
            this.GarageHeight = data.GarageHeight;
            this.AvailabilityOfElectricity = data.AvailabilityOfElectricity;
            this.CentralHeating = data.CentralHeating;
            this.ViewingHole = data.ViewingHole;
            this.TwoParkingLots = data.TwoParkingLots;
            this.Basement = data.Basement;
            this.PresenceOfSecurity = data.PresenceOfSecurity;
            this.AvailabilityOfWaterSupplySewerage = data.AvailabilityOfWaterSupplySewerage;
            this.PresenceOfVideoSurveillance = data.PresenceOfVideoSurveillance;
            this.LandCategory = data.LandCategory;
            this.PermittedUse = data.PermittedUse;
            this.DistanceToMotorway = data.DistanceToMotorway;
            this.AvailabilityOfFreeAccessToTheSite = data.AvailabilityOfFreeAccessToTheSite;
            this.TotalBuildingArea = data.TotalBuildingArea;
            this.PresenceOfBuildingsStructuresForDemolition = data.PresenceOfBuildingsStructuresForDemolition;
            this.HaveTrainStation = data.HaveTrainStation;
            this.AvailabilityOfGasSupply = data.AvailabilityOfGasSupply;
            this.AvailabilityOfPowerSupply = data.AvailabilityOfPowerSupply;
            this.BuildingPermit = data.BuildingPermit;
            this.BuildingPermitComments = data.BuildingPermitComments;
            this.TerritoryPlanningProject = data.TerritoryPlanningProject;
            this.InitialPermitDocumentation = data.InitialPermitDocumentation;
        }
    }
}
