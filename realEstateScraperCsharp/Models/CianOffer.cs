using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static realEstateScraperCsharp.Form1;

namespace realEstateScraperCsharp.Models
{

    class CianOfferGeoCoordinates {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }

    class CianOfferGeoAddress
    {
        public string FullName { get; set; }
        public string GeoType { get; set; }
        public int ID { get; set; }
        public int LocationTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    public class CianOfferGeoUndergrounds
    {
        string LineColor { get; set; }
        int Time { get; set; }
        string TransportType { get; set; }
    }

    class CianOfferGeo
    {
        public string UserInput { get; set; }
        public CianOfferGeoAddress[] Address { get; set; }
        public CianOfferGeoCoordinates Coordinates { get; set; }
        public CianOfferGeoUndergrounds[] Undergrounds { get; set; }
    }

    class CianOfferSpecialtySpecialtiesElement
    {
        public string RusName { get; set; }
    }

    class CianOfferSpecialty
    {
        public CianOfferSpecialtySpecialtiesElement[] Specialties { get; set; }
    }

    class CianOfferBargainTerms
    {
        public string Currency { get; set; }
        public string LeaseTermType { get; set; }
        public string LeaseType { get; set; }
        public string PaymentPeriod { get; set; }
        public float Price { get; set; }
        public float PriceRur { get; set; }
        public string PriceType { get; set; }
    }

    class CianOfferBuildingParking
    {
        public string Currency { get; set; }
        //object IsFree { get; set; }
        //object LocationType { get; set; }
        public int PlacesCount { get; set; }
        public string Type { get; set; }
    }
    class CianOfferBuilding
    {
        public int BuildYear { get; set; }
        public int CargoLiftsCount { get; set; }
        public int PassengerLiftsCount { get; set; }
        public string ClassType { get; set; }
        public int FloorsCount { get; set; }
        public string HeatingType { get; set; }
        public string MaterialType { get; set; }
        public string Type { get; set; }
        public CianOfferBuildingParking Parking { get; set; }
    }

    class CianOfferLand
    {
        public string Area { get; set; }
        public string AreaUnitType { get; set; }
        public string Type { get; set; }
    }

    internal class CianOffer
    {
        public int ID { get; set; }
        public int CianId { get; set; } //Идентификатор cian id
        public object[] Phones { get; set; } //Номер телефона
        public string CadastralNumber { get; set; } //Кадастровый номер
        public string FullUrl { get; set; } //Источник информации
        public int AddedTimestamp { get; set; } //Дата публикации в виде Timestamp
        public float TotalArea { get; set; }
        public string Description { get; set; } //Описание
        public string DealType { get; set; }
        public string OfficeType { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public CianOfferGeo Geo { get; set; } //Объект Гео
        public CianOfferSpecialty Specialty { get; set; }
        public CianOfferBargainTerms BargainTerms { get; set; }
        public CianOfferBuilding Building { get; set; }
        public CianOfferLand Land { get; set; }
    }
}
