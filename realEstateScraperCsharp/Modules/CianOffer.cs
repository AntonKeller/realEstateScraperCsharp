using Esprima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static realEstateScraperCsharp.Form1;

namespace realEstateScraperCsharp.Modules
{
    class Offer
    {
        public int? ID { get; set; }
    }

    class CianOfferGeoCoordinates {
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }

    class CianOfferGeoAddress
    {
        public string FullName { get; set; }
        public string GeoType { get; set; }
        public int? ID { get; set; }
        public int? LocationTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    public class CianOfferGeoUndergrounds
    {
        public string Name { get; set; }
        public string LineColor { get; set; }
        public int? Time { get; set; }
        public string TransportType { get; set; }
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
        public string EngName { get; set; }
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
        public string VatType { get; set; }
        public float? Price { get; set; }
        public float? PriceRur { get; set; }
        public string PriceType { get; set; }
    }

    class CianOfferBuildingParking
    {
        public string Currency { get; set; }
        //object IsFree { get; set; }
        //object LocationType { get; set; }
        public int? PlacesCount { get; set; }
        public string Type { get; set; }
    }
    class CianOfferBuilding
    {
        public int? BuildYear { get; set; }
        public int? CargoLiftsCount { get; set; }
        public int? PassengerLiftsCount { get; set; }
        public string ClassType { get; set; }
        public int? FloorsCount { get; set; }
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

    class Phone
    {
        public string countryCode { get; set; }
        public string number { get; set; }
    }

    class CianOfferGarage
    {
        public string GarageType { get; set; }
        public string Material { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }

    internal class CianOffer: Offer
    {
        public int? CianId { get; set; } //Идентификатор cian id
        public string CadastralNumber { get; set; } //Кадастровый номер
        public string FullUrl { get; set; } //Источник информации
        public int? AddedTimestamp { get; set; } //Дата публикации в виде Timestamp
        public float? TotalArea { get; set; }
        public string Description { get; set; } //Описание
        public string DealType { get; set; }
        public string OfficeType { get; set; }
        public string Category { get; set; }
        public string OfferType { get; set; }
        public string Title { get; set; }
        public string publicationDate { get; set; }
        public int? floorNumber { get; set; }
        public CianOfferGarage Garage { get; set; }
        public Phone[] Phones { get; set; } //Номер телефона
        public CianOfferGeo Geo { get; set; } //Объект Гео
        public CianOfferSpecialty Specialty { get; set; }
        public CianOfferBargainTerms BargainTerms { get; set; }
        public CianOfferBuilding Building { get; set; }
        public CianOfferLand Land { get; set; }
    }
}
