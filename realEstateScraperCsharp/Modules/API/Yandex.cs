using Microsoft.Playwright;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace realEstateScraperCsharp.Modules.API
{

    class TComponent
    {
        public string kind { get; set; }
        public string name { get; set; }
    }

    class TAddress
    {
        public string formatted { get; set; }
        public TComponent[] Components { get; set; }
    }

    class GeocoderMetaData
    {
        public TAddress Address { get; set; }
        public string text { get; set; }
    }

    class MetaDataProperty
    {
        public GeocoderMetaData GeocoderMetaData { get; set; }
    }

    class TPoint
    {
        public string pos { get; set; }
    }

    class GeoObject
    {
        public MetaDataProperty metaDataProperty { get; set; }
        public TPoint Point { get; set; }
    }

    class TFeatureMember
    {
        public GeoObject GeoObject { get; set; }
    }

    class TGeoObjectCollection
    {
        public TFeatureMember[] featureMember { get; set; }
    }

    class Response
    {
        public TGeoObjectCollection GeoObjectCollection { get; set; }
    }


    class Box
    {
        public Response response { get; set; }
    }

    class AreaInfo()
    {
        public static AreaInfo Compare(AreaInfo first, AreaInfo second)
        {
            var buff = new AreaInfo();

            if (first.InputAddress != null && first.InputAddress.Length > 0)
                buff.InputAddress = first.InputAddress;
            else if (second.InputAddress != null && second.InputAddress.Length > 0)
                buff.InputAddress = second.InputAddress;

            if (first.CorrectAddress != null && first.CorrectAddress.Length > 0)
                buff.CorrectAddress = first.CorrectAddress;
            else if (second.CorrectAddress != null && second.CorrectAddress.Length > 0)
                buff.CorrectAddress = second.CorrectAddress;

            if (first.Country != null && first.Country.Length > 0)
                buff.Country = first.Country;
            else if (second.Country != null && second.Country.Length > 0)
                buff.Country = second.Country;

            if (first.FederalOkrug != null && first.FederalOkrug.Length > 0)
                buff.FederalOkrug = first.FederalOkrug;
            else if (second.FederalOkrug != null && second.FederalOkrug.Length > 0)
                buff.FederalOkrug = second.FederalOkrug;

            if (first.Region != null && first.Region.Length > 0)
                buff.Region = first.Region;
            else if (second.Region != null && second.Region.Length > 0)
                buff.Region = second.Region;

            buff.IsFederalCity = first.IsFederalCity || second.IsFederalCity;

            if (first.MunicipalOkrug != null && first.MunicipalOkrug.Length > 0)
                buff.MunicipalOkrug = first.MunicipalOkrug;
            else if (second.MunicipalOkrug != null && second.MunicipalOkrug.Length > 0)
                buff.MunicipalOkrug = second.MunicipalOkrug;

            if (first.MunicipalRaion != null && first.MunicipalRaion.Length > 0)
                buff.MunicipalRaion = first.MunicipalRaion;
            else if (second.MunicipalRaion != null && second.MunicipalRaion.Length > 0)
                buff.MunicipalRaion = second.MunicipalRaion;

            if (first.City != null && first.City.Length > 0)
                buff.City = first.City;
            else if (second.City != null && second.City.Length > 0)
                buff.City = second.City;

            if (first.CitySettlement != null && first.CitySettlement.Length > 0)
                buff.CitySettlement = first.CitySettlement;
            else if (second.CitySettlement != null && second.CitySettlement.Length > 0)
                buff.CitySettlement = second.CitySettlement;

            if (first.CityOkrug != null && first.CityOkrug.Length > 0)
                buff.CityOkrug = first.CityOkrug;
            else if (second.CityOkrug != null && second.CityOkrug.Length > 0)
                buff.CityOkrug = second.CityOkrug;

            if (first.CityRaion != null && first.CityRaion.Length > 0)
                buff.CityRaion = first.CityRaion;
            else if (second.CityRaion != null && second.CityRaion.Length > 0)
                buff.CityRaion = second.CityRaion;

            if (first.CityMikroraion != null && first.CityMikroraion.Length > 0)
                buff.CityMikroraion = first.CityMikroraion;
            else if (second.CityMikroraion != null && second.CityMikroraion.Length > 0)
                buff.CityMikroraion = second.CityMikroraion;

            if (first.CitySection != null && first.CitySection.Length > 0)
                buff.CitySection = first.CitySection;
            else if (second.CitySection != null && second.CitySection.Length > 0)
                buff.CitySection = second.CitySection;

            if (first.Street != null && first.Street.Length > 0)
                buff.Street = first.Street;
            else if (second.Street != null && second.Street.Length > 0)
                buff.Street = second.Street;

            if (first.House != null && first.House.Length > 0)
                buff.House = first.House;
            else if (second.House != null && second.House.Length > 0)
                buff.House = second.House;

            if (first.Lat != null && first.Lat.Length > 0)
                buff.Lat = first.Lat;
            else if (second.Lat != null && second.Lat.Length > 0)
                buff.Lat = second.Lat;

            if (first.Lon != null && first.Lon.Length > 0)
                buff.Lon = first.Lon;
            else if (second.Lon != null && second.Lon.Length > 0)
                buff.Lon = second.Lon;

            return buff;
        }

        public string InputAddress { get; set; }    // Входной адрес
        public string CorrectAddress { get; set; }  // Полный скорректированный адрес
        public string Country { get; set; }         // Страна
        public string FederalOkrug { get; set; }    // Федеральный округ
        public string Region { get; set; }          // Регион
        public bool IsFederalCity { get; set; }   // Является федеральным городом
        public string MunicipalOkrug { get; set; }  // Муниципальный округ
        public string MunicipalRaion { get; set; }  // Муниципальный район
        public string City { get; set; }            // Город
        public string CitySettlement { get; set; }  // Городское поселение
        public string CityOkrug { get; set; }       // Административный округ
        public string CityRaion { get; set; }       // Административный район
        public string CityMikroraion { get; set; }  // Микрорайон
        public string CitySection { get; set; }     // Квартал
        public string Street { get; set; }          // Улица
        public string House { get; set; }           // Дом
        public string Lat { get; set; }             // Широта
        public string Lon { get; set; }             // Долгота
    }

    class SCO
    {
        public static string LonLat = "&sco=longlat"; //| — долгота, широта
        public static string LatLon = "&sco=latlong"; //| — широта, долгота
    }

    class KIND {
        public static string District = "&kind=district"; //| район города
        public static string Metro = "&kind=metro";       //| станция метро
        public static string House = "&kind=house";       //| дом
        public static string Street = "&kind=street";     //| улица
        public static string Locality = "&kind=locality"; //| населенный пункт (город/поселок/деревня/село/...)
    }

    class FORMAT
    {
        public static string Xml = "&format=xml";
        public static string Json = "&format=json";
    }

    class YDomain
    {
        public static string Base = "https://geocode-maps.yandex.ru/1.x/?";
    }

    class Tokens
    {
        public static string Base = "bd9aa639-828c-4fd1-96ce-fc519d09f7d2";
    }



    internal class YandexAPI
    {
        static HttpClient httpClient = new HttpClient();

        private AreaInfo ParseComponents(Box YandexResponseBox)
        {
            var areaInfo = new AreaInfo();

            if (YandexResponseBox.response.GeoObjectCollection.featureMember.Length > 0)
            {
                var feature0 = YandexResponseBox.response.GeoObjectCollection.featureMember[0];

                // Получаем скорректированный адрес
                areaInfo.CorrectAddress = feature0.GeoObject.metaDataProperty.GeocoderMetaData.text;

                // Определяем координаты Lat/Lon
                if (feature0.GeoObject.Point.pos.Length > 0)
                {
                    var splt = feature0.GeoObject.Point.pos.Split(' ');
                    if (splt.Length == 2)
                    {
                        areaInfo.Lat = splt[1];
                        areaInfo.Lon = splt[0];
                    }
                }

                // Определяем остальные хар-ки
                foreach (var component in feature0.GeoObject.metaDataProperty.GeocoderMetaData.Address.Components)
                {
                    // Парсинг страны
                    var countryKindTest = new Regex("country", RegexOptions.IgnoreCase);
                    if (countryKindTest.IsMatch(component.kind))
                    {
                        areaInfo.Country = component.name;
                    }

                    // парсинг федерального округа
                    var federalOkrugKindTest = new Regex("province", RegexOptions.IgnoreCase);
                    var federalOkrugNameTest1 = new Regex("федерал", RegexOptions.IgnoreCase);
                    var federalOkrugNameTest2 = new Regex("округ", RegexOptions.IgnoreCase);
                    if (
                        federalOkrugKindTest.IsMatch(component.kind) &&
                        federalOkrugNameTest1.IsMatch(component.name) &&
                        federalOkrugNameTest2.IsMatch(component.name)
                        )
                    {
                        areaInfo.FederalOkrug = component.name;
                    }

                    //| Тесты на: республику, край, область (Приоритет 1)
                    var regionOtherKindTest = new Regex("province", RegexOptions.IgnoreCase);
                    var regionOtherNameTest = new Regex("республика|край|область", RegexOptions.IgnoreCase);
                    if (regionOtherKindTest.IsMatch(component.kind) && regionOtherNameTest.IsMatch(component.name))
                    {
                        areaInfo.Region = component.name;
                    }

                    //| Тесты на: автономные округа или автономные области (Приоритет 2)
                    var regionAutonomicKindTest = new Regex("province", RegexOptions.IgnoreCase);
                    var regionAutonomicNameTest = new Regex("(автономный|автономная)\\s?(округ|область)", RegexOptions.IgnoreCase);
                    if (regionAutonomicKindTest.IsMatch(component.kind) && regionAutonomicNameTest.IsMatch(component.name))
                    {
                        // ~~ Убрать из "name" ключевые слова: (автономный, автономная)
                        areaInfo.Region = component.name;
                    }

                    // Тесты на: федеральный город (Приоритет 3)
                    var federalCityKindTest = new Regex("province", RegexOptions.IgnoreCase);
                    var federalCityNameTest = new Regex("федеральный|округ|область|край|республика", RegexOptions.IgnoreCase);
                    if (federalCityKindTest.IsMatch(component.kind) && !federalCityNameTest.IsMatch(component.name))
                    {
                        areaInfo.Region = component.name;
                        areaInfo.City = component.name;
                        areaInfo.IsFederalCity = true;
                    }

                    // Тесты на: муниципальный округ
                    var municipalOkrugKindTest = new Regex("area", RegexOptions.IgnoreCase);
                    var municipalOkrugNameTest1 = new Regex("муниципальный", RegexOptions.IgnoreCase);
                    var municipalOkrugNameTest2 = new Regex("округ", RegexOptions.IgnoreCase);
                    if (municipalOkrugKindTest.IsMatch(component.kind) && municipalOkrugNameTest1.IsMatch(component.name) && municipalOkrugNameTest2.IsMatch(component.name))
                    {
                        // ~~ Убрать ключевые слова: (муниципальный, округ, муниципальный округ)
                        areaInfo.MunicipalOkrug = component.name;
                    }

                    // Тесты на: муниципальный район
                    var municipalRaionKindTest = new Regex("area", RegexOptions.IgnoreCase);
                    var municipalRaionNameTest1 = new Regex("муниципальный", RegexOptions.IgnoreCase);
                    var municipalRaionNameTest2 = new Regex("район", RegexOptions.IgnoreCase);
                    if (municipalRaionKindTest.IsMatch(component.kind) && municipalRaionNameTest1.IsMatch(component.name) && municipalRaionNameTest2.IsMatch(component.name))
                    {
                        // ~~ Убрать ключевые слова: (муниципальный, район, муниципальный район)
                        areaInfo.MunicipalRaion = component.name;
                    }

                    // Тесты на: села, поселения внутри города
                    var citySettlementKindTest = new Regex("locality", RegexOptions.IgnoreCase);
                    if (citySettlementKindTest.IsMatch(component.kind))
                    {
                        if (areaInfo.City.Length > 0)
                            areaInfo.CitySettlement = component.name;
                        else
                            areaInfo.City = component.name;
                    }

                    // Тесты на: административный округ, городской округ
                    var adminOkrugKindTest = new Regex("district|area", RegexOptions.IgnoreCase);
                    var adminOkrugNameTest1 = new Regex("административный|городской", RegexOptions.IgnoreCase);
                    var adminOkrugNameTest2 = new Regex("округ", RegexOptions.IgnoreCase);
                    if (adminOkrugKindTest.IsMatch(component.kind) && adminOkrugNameTest1.IsMatch(component.name) && adminOkrugNameTest2.IsMatch(component.name))
                    {
                        areaInfo.CityOkrug = component.name;
                    }

                    // Тесты на: административный район
                    var adminRaionKindTest = new Regex("district", RegexOptions.IgnoreCase);
                    var adminRaionNameTest1 = new Regex("квартал|кв-л", RegexOptions.IgnoreCase);
                    var adminRaionNameTest2 = new Regex("мкр-н|мкр\\.|микрорайон", RegexOptions.IgnoreCase);
                    var adminRaionNameTest3 = new Regex("жилой|комплекс|жилой комплекс", RegexOptions.IgnoreCase);
                    var adminRaionNameTest4 = new Regex("административный|округ|административный округ", RegexOptions.IgnoreCase);
                    var adminRaionNameTest5 = new Regex("муниципальный|округ|муниципальный округ", RegexOptions.IgnoreCase);
                    if (
                        adminRaionKindTest.IsMatch(component.kind) &&
                        !adminRaionNameTest1.IsMatch(component.name) &&
                        !adminRaionNameTest2.IsMatch(component.name) &&
                        !adminRaionNameTest3.IsMatch(component.name) &&
                        !adminRaionNameTest4.IsMatch(component.name) &&
                        !adminRaionNameTest5.IsMatch(component.name)
                        )
                    {
                        // ~~ Вырезать из наименования: "р-н|рн\.|район|село|поселение|поселок"
                        areaInfo.CityRaion = component.name;
                    }

                    // Заносим поселение как город
                    if (areaInfo.City == areaInfo.CityRaion)
                    {
                        areaInfo.City = areaInfo.Region;
                    }

                    // Тесты на: микрорайон
                    var cityMikroraionKindTest = new Regex("district", RegexOptions.IgnoreCase);
                    var cityMikroraionNameTest = new Regex("микрорайон|мкр-н|мкр.", RegexOptions.IgnoreCase);
                    if (cityMikroraionKindTest.IsMatch(component.kind) && cityMikroraionNameTest.IsMatch(component.name))
                    {
                        areaInfo.CityMikroraion = component.name;
                    }

                    // Тесты на: квартал
                    var sectionKindTest = new Regex("district", RegexOptions.IgnoreCase);
                    var sectionNameTest = new Regex("квартал", RegexOptions.IgnoreCase);
                    if (sectionKindTest.IsMatch(component.kind) && sectionNameTest.IsMatch(component.name))
                    {
                        areaInfo.CitySection = component.name;
                    }

                    // Тесты на: улицу
                    var streetKindTest = new Regex("street", RegexOptions.IgnoreCase);
                    if (streetKindTest.IsMatch(component.kind))
                    {
                        areaInfo.Street = component.name;
                    }

                    // Тесты на: номер дома
                    var houseKindTest = new Regex("house", RegexOptions.IgnoreCase);
                    if (houseKindTest.IsMatch(component.kind))
                    {
                        areaInfo.House = component.name;
                    }
                }
            }

            return areaInfo;
        }

        private async Task<Box> APIRequest(string strRequest)
        {
            using HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, strRequest);
            using HttpResponseMessage response = await httpClient.SendAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Box>(responseString);
        }

        public async Task<AreaInfo> GetInfoByAddress(string token, string geocode)
        {
            
            // Запрос 1 на получение информации (по адресу)
            var messageString1 = $"{YDomain.Base}apikey={token}&geocode={geocode}{FORMAT.Json}{SCO.LatLon}{KIND.District}";
            var JsonResponse1 = await APIRequest(messageString1);
            var parseData1 = ParseComponents(JsonResponse1);

            
            // Запрос 2 на получение информации (по координатам, при их наличии)
            var messageString2 = $"{YDomain.Base}apikey={token}&geocode={parseData1.Lat},{parseData1.Lon}{FORMAT.Json}{SCO.LatLon}{KIND.District}";
            var JsonResponse2 = await APIRequest(messageString2);
            var parseData2 = ParseComponents(JsonResponse2);

            
            // Объеденияем два распаршеных объекта и возвращаем
            return AreaInfo.Compare(parseData1, parseData2);
        }
    }
}
