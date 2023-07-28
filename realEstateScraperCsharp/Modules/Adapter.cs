using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace realEstateScraperCsharp.Modules
{
    internal class AdapterRealEstateData
    {
        public CompleteFields TranslateFromCian(CianOffer offer)
        {
            //Словарь для типов субъектов
            var subjectTypes = new Dictionary<int, string>(){
                [1] = "Город федерального значения",
                [2] = "Область",
                [135] = "Автономный округ",
                [136] = "Автономная область",
                [138] = "Край",
                [140] = "Республика"
            };

            //Словарь тестов для определения типов поселений
            var localityTypesTests = new Dictionary<string, string>()
            {
                ["хутор"] = "Хутор",
                ["пгт[\\s.]|\\sпгт|поселок городского"] = "Поселок городского типа",
                ["рп[\\s.]|\\sрп|рабочий поселок"] = "Рабочий посёлок",
                ["кп[\\s.]|курортный поселок"] = "Курортный поселок",
                ["дп[\\s.]|дачный поселок"] = "Дачный поселок",
                ["пос[\\s.]|поселок"] = "Поселок",
                ["поселение"] = "Поселение",
                ["с[\\s.]|село"] = "Село",
            };

            CompleteFields data = new CompleteFields();

            data.Id = 1;
            data.InsideId = offer.CianId;

            if (offer.Phones != null && offer.Phones.Length == 1)
            {
                foreach(var phone in offer.Phones)
                {
                    data.PhoneNumber += $"8{phone.number},";
                }
            }
            data.CadNumber = offer.CadastralNumber;
            data.CardUrl = offer.FullUrl;
            data.PublicationDate = $"{offer.AddedTimestamp}"; // Сделать перевод в дату!
            data.EconomicZone = null;

            if (offer.Geo != null && offer.Geo.Address != null)
            {
                data.Address = offer.Geo.UserInput;
                data.Lat = $"{offer.Geo.Coordinates?.Lat}";
                data.Lon = $"{offer.Geo.Coordinates?.Lng}";
                
                if (offer.Geo.Address.Length > 0)
                {
                    data.Subject = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "location" &&
                        e.Type == "location" &&
                        e.LocationTypeId != null &&
                        subjectTypes.ContainsKey((int)e.LocationTypeId);
                    })?.Title;

                    var okrugTest = new Regex("округ|окр\\.", RegexOptions.IgnoreCase);
                    data.MunOkrug = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "location" &&
                        e.Type == "location" &&
                        okrugTest.IsMatch(e.FullName);
                    })?.Title;

                    var raionTest = new Regex("район|рн\\.|р-н", RegexOptions.IgnoreCase);
                    data.MunRaion = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "location" &&
                        e.Type == "location" &&
                        raionTest.IsMatch(e.FullName);
                    })?.Title;

                    data.City = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "location" && e.LocationTypeId == 1;
                    })?.Title;

                    var localityFiltered = Array.FindAll(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "location" && e.Type == "location";
                    });
                    if (localityFiltered != null && localityFiltered.Length > 1)
                    {
                        bool flag = false;

                        for (int i = 0; i < localityFiltered.Length; i++)
                        {
                            var fullName = localityFiltered[i].FullName;

                            for (int j = 0; j < localityTypesTests.Count; j++)
                            {
                                if (Regex.IsMatch(fullName, localityTypesTests.ElementAt(j).Key, RegexOptions.IgnoreCase))
                                {
                                    flag = true;
                                    data.Locality = localityFiltered[i].Title;
                                    data.LocalityType = localityTypesTests.ElementAt(j).Value;
                                    break;
                                }
                            }
                            if (flag) break;
                        }
                    }

                    data.Okrug = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "district" && e.Type == "okrug";
                    })?.Title;

                    data.Raion = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.GeoType == "district" && e.Type == "raion";
                    })?.ShortName;

                    data.Mikroraion = Array.Find(offer.Geo.Address, e => // сократить в одну строку!!
                    {
                        return e.Type == "mikroraion";
                    })?.Title;

                    data.Section = Array.Find(offer.Geo.Address, e =>
                    {
                        return e.Type == "location" &&
                        (new Regex("кв-л", RegexOptions.IgnoreCase).IsMatch(e.ShortName) ||
                        new Regex("квартал", RegexOptions.IgnoreCase).IsMatch(e.ShortName) ||
                        new Regex("кв-л", RegexOptions.IgnoreCase).IsMatch(e.FullName) ||
                        new Regex("квартал", RegexOptions.IgnoreCase).IsMatch(e.FullName));
                    })?.Title;
                }
            }

            if (offer.Geo.Undergrounds != null && offer.Geo.Undergrounds.Length > 0)
            {
                var walkFound = Array.FindAll(offer.Geo.Undergrounds, e => e.TransportType == "walk");
                if (walkFound != null && walkFound.Length > 0)
                {
                    Array.Sort(walkFound, (x, y) =>
                    {
                        if (x.Time > y.Time) return 1;
                        if (x.Time < y.Time) return -1;
                        return 0;
                    });
                    data.MetroWalkName = walkFound[0].Name;
                    data.MetroWalkDistance = walkFound[0].Time;
                }

                var TransportFound = Array.FindAll(offer.Geo.Undergrounds, e => e.TransportType == "transport");
                if (TransportFound != null && TransportFound.Length > 0)
                {
                    Array.Sort(TransportFound, (x, y) =>
                    {
                        if (x.Time > y.Time) return 1;
                        if (x.Time < y.Time) return -1;
                        return 0;
                    });
                    data.MetroTransportName = TransportFound[0].Name;
                    data.MetroTransportDistance = TransportFound[0].Time;
                }
            }

            //| Описание
            data.Description = offer?.Description;

            //| Тип сделки
            data.DealType = offer?.DealType;

            //| Состав передаваемых прав
            var rightsFound = Regex.Match(offer.Description, "(([вВ]ид|[тТ]ип)[а-яА-Я:\\s=-]*([пП]рав[оа])[а-яА-Я:\\s=-]*собственность)|(([вВ]ид|[тТ]ип)[а-яА-Я:\\s=-]*([пП]рав[оа])[а-яА-Я:\\s=-]*аренда)", RegexOptions.IgnoreCase);
            if (rightsFound.Success)
            {
                if (Regex.IsMatch(rightsFound.Value, "собственность", RegexOptions.IgnoreCase))
                    data.TransferredRights = "Собственность";
                else if (Regex.IsMatch(rightsFound.Value, "аренда", RegexOptions.IgnoreCase))
                    data.TransferredRights = "Аренда";
            }

            //Комменты к сделке
            if (Regex.IsMatch(offer.Description, "торги|аукцион", RegexOptions.IgnoreCase))
                data.DealComments = "Аукцион";

            //Функциональное назначение
            data.FunctionalPurpose = offer?.OfficeType != null ? offer?.OfficeType : offer?.Category;

            //Варианты использования
            foreach (var e in offer.Specialty.Specialties)
                data.Specialty += $"{e.RusName}, ";

            //НДС
            data.VatType = offer?.BargainTerms?.VatType;

            //Цена предложения
            data.Price = offer?.BargainTerms?.Price;

            //| Корректируем типу цены
            if (offer?.BargainTerms?.PriceType == "squareMeter")
                data.Price *= offer.TotalArea ?? 1;
            
            //| Корректируем цену по платежному периоду
            if (offer?.BargainTerms?.PaymentPeriod == "annual")
                data.Price /= 12;

            //Тип отопления
            data.HeatingType = offer?.Building?.HeatingType;

            //| Добавить статическое поле счетчик возможность
            data.AnalogNumber = 1;

            //Дата парсинга данных - СКОРРЕКТИРОВАТЬ
            data.ParseDate = DateTime.Now;

            //| Общая площадь
            data.TotalArea = offer?.TotalArea;

            //| Тип объекта
            data.ObjectType = offer?.Building?.Type;

            //| Класс здания
            data.BuildingClassType = offer?.Building?.ClassType;

            //| Возраст здания
            data.BuildYearsOld = offer?.Building?.BuildYear;

            //| Материал здания
            data.BuildMaterial = offer?.Building?.MaterialType;

            //| Этаж/Этажность
            data.FloorsCount = $"{offer?.floorNumber}/{offer?.Building?.FloorsCount}";

            //| Наличие центрального отопления
            data.CentralHeating = offer?.Building?.HeatingType;

            //| Тип парковки
            data.ParkingType = offer?.Building?.Parking?.Type;

            //| Количество парковочных мест, шт.
            data.NumberOfParkingSpaces = offer?.Building?.Parking?.PlacesCount;

            //| Наличие двух парковочных мест
            if (data.NumberOfParkingSpaces != null)
                data.TwoParkingLots = data.NumberOfParkingSpaces >= 2 ? "Да" : "Нет";

            //| Парсинг описания
            if (offer.Description != null && offer.Description.Length > 9)
            {
                //Тип здания (отдельно стоящее, втроенное помещение и т.д.)
                var testVP = new Regex("([пП]рода([её]тся|м|ю|[её]м|дим)|предлагается на продажу).{1,50}(встроенное помещение|в отдельно|весь этаж|в подвале|на цокольном этаже|на (первом|\\d{1,2})(-ом|-м)? этаже|в бизнес[-\\s]?центре|в бц|в тц|в торговом центре|в жилом доме|квартира|нежилое помещение|офисное помещение|торговое помещение|нежилые помещения|в деловом центре|част[ьи] здания|в многоквартирном доме)", RegexOptions.IgnoreCase);
                var testOSZ = new Regex("([пП]рода([её]тся|м|ю|[её]м|дим)|предлагается на продажу).{1,50}(отдельно[-\\s]?стоящ(ее|ий)|площадь зу|офисный блок|здание торгового центра|торговый центр|(ми|но|ух|[её]х|ти|\\dх|\\d-х)этажное здание|земельный участок|соток)", RegexOptions.IgnoreCase);
                if (testVP.IsMatch(offer.Description))
                    data.BuildType = "ВП";
                else if(testOSZ.IsMatch(offer.Description))
                    data.BuildType = "ОСЗ";

                //| Наличие отдельного входа
                var notHaveEntryTest = new Regex("без отдельного входа", RegexOptions.IgnoreCase);
                var haveEntryTest = new Regex("независимых входа|вход.{1,10}отдельных|отдельный вход|отдельных входа|Собственный вход", RegexOptions.IgnoreCase);
                if (notHaveEntryTest.IsMatch(offer.Description))
                    data.HavingSeparateEntrance = false;
                else if (haveEntryTest.IsMatch(offer.Description))
                    data.HavingSeparateEntrance = true;

                //| Вход со двора
                var entryFromTheYardTest = new Regex("вход.{1,10}со.{1,10}двора", RegexOptions.IgnoreCase);
                if (entryFromTheYardTest.IsMatch(offer.Description))
                    data.EntranceFromTheYard = "Да";

                //| Вход с улицы
                var entryFromTheStreetTest = new Regex("вход.{1,10}с.{1,10}улицы", RegexOptions.IgnoreCase);
                if (entryFromTheStreetTest.IsMatch(offer.Description))
                    data.EntranceFromTheStreet = "Да";

                //| Гаражный бокс
                var IsGarageBoxTest = new Regex("гаражный бокс", RegexOptions.IgnoreCase);
                if(IsGarageBoxTest.IsMatch(offer.Description))
                    data.IsGarageBox = "Да";

                //| Уровень гаража
                var garageLvlTest = new Regex("(\\d+)[а-яА-Я,.:=\\s]{1,10} уровневый", RegexOptions.IgnoreCase);
                if (garageLvlTest.IsMatch(offer.Description))
                {
                    var buffStr = garageLvlTest.Match(offer.Description).Value;
                    var numTest = new Regex("(\\d+)", RegexOptions.IgnoreCase);
                    data.GarageLevel = int.Parse(numTest.Match(buffStr).Value);
                }

                //| Тип гаража
                if (offer.Garage != null && offer.Garage.Type != null)
                    data.GarageType = offer.Garage.Type;
                else
                {
                    if (Regex.IsMatch(offer.Description, "[гГ]араж.{1,60}металлический|[мМ]еталлический.{1,30}гараж", RegexOptions.IgnoreCase))
                        data.GarageType = "Металлический";
                    else if (Regex.IsMatch(offer.Description, "[гГ]араж.{1,60}кирпичный|[кК]ирпичный.{1,30}гараж|гараж.{1,20}из.{1,20}кирпича", RegexOptions.IgnoreCase))
                        data.GarageType = "Кирпичный";
                    else if(Regex.IsMatch(offer.Description, "железобетонный|в железобетонном исполнении|из железобетона", RegexOptions.IgnoreCase))
                        data.GarageType = "Железобетонный";
                }

                //| Статус гаража
                data.GarageStatus = offer.Garage?.Status;

                //| Высота ворот, м.
                var subStrBuffTest = new Regex("ворота.{1,40}(высота.{1,40}\\d+(\\s?\\d*)*([.,]\\d+)?м)", RegexOptions.IgnoreCase);
                if (subStrBuffTest.IsMatch(offer.Description))
                {
                    var subStrBuff = subStrBuffTest.Match(offer.Description).Value;
                    var buffValueTest = new Regex("\\d+(\\s?\\d*)*([.,]\\d+)?", RegexOptions.IgnoreCase);
                    data.GateHeight = float.Parse(buffValueTest.Match(subStrBuff).Value);
                }

                //| наличие электричества
                var electricityTest = new Regex("электричество|электроснабжение|электропроводка|электросчетчик", RegexOptions.IgnoreCase);
                if (electricityTest.IsMatch(offer.Description))
                    data.AvailabilityOfElectricity = "Да";

                //| Наличие смотровой ямы
                var notHaveHoleTest = new Regex("Смотровой ямы нет|Ямы нет", RegexOptions.IgnoreCase);
                var haveHoleTest = new Regex("\\s[яЯ]м[ыа]", RegexOptions.IgnoreCase);
                if (notHaveHoleTest.IsMatch(offer.Description))
                    data.ViewingHole = "Нет";
                else if (haveHoleTest.IsMatch(offer.Description))
                    data.ViewingHole = "Да";

                //| Наличие подвала
                if (Regex.IsMatch(offer.Description, "без подвала", RegexOptions.IgnoreCase))
                    data.Basement = "Нет";
                else if (
                    Regex.IsMatch(offer.Description, "[сС] подвалом|,.{1,15}подвал.{1,15},|[еЕ]?сть подвал", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "и подвал|[сС]ухой подвал|иИмеется подвал", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, ",.{1,10}подвал.{1,10}\\.|подвальное помещение", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "(.{1,15}[пП]одвал.{1,15})|[иИ]меется.{1,30}подвал", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "подвал.{1,10}\\d.{1,6}кв|\\+подвал|[пП]одвал в.{1,10}\\d.{1,6}этажа", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[пП]одвал в.{1,10}\\d.{1,6}метров|[пП]одвал в.{1,10}\\d.{1,6}кв\\.м|[пП]одвал[.,+]", RegexOptions.IgnoreCase)
                ) data.Basement = "Да";

                //| Наличие охраны
                if (Regex.IsMatch(offer.Description, "охрана", RegexOptions.IgnoreCase))
                    data.PresenceOfSecurity = "Да";

                //| Наличие водоснабжения
                if (Regex.IsMatch(offer.Description, "([вВ] гараже есть|[еЕ]сть все коммуникации|[цЦ]ентральное отопление|[пП]роведено).{1,30}вода", RegexOptions.IgnoreCase))
                    data.AvailabilityOfWaterSupplySewerage = "Да";

                //| Наличие видеонаблюдения
                if (Regex.IsMatch(offer.Description, "видеонаблюдение", RegexOptions.IgnoreCase))
                    data.PresenceOfVideoSurveillance = "Да";

                //| Категория земель
                if (Regex.IsMatch(offer.Description, "[зЗ]емли населенных пунктов", RegexOptions.IgnoreCase))
                    data.LandCategory = "Земли населенных пунктов";

                //| Наличие свободного подъезда к участку
                if (
                    Regex.IsMatch(offer.Description, "участие в.{1,50}\\sподъезд[оаы,.\\s-]", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "озможн.{1,50}\\sподъезд[оаы,.\\s-]", RegexOptions.IgnoreCase)
                ) data.AvailabilityOfFreeAccessToTheSite = "Нет";
                else if (Regex.IsMatch(offer.Description, "\\sподъезд", RegexOptions.IgnoreCase))
                    data.AvailabilityOfFreeAccessToTheSite = "Да";

                //| Площадь зданий на участке, кв. м
                var foundBuildingsTest = new Regex("(([сС]троения|[кК]омплекс зданий|[кК]омплекс|здани[яй]|Комплекс представляет собой|Комплекс состоит из).{0,80}(общей|суммарн(ая|ой)) площадью)[\\s:=_-]*(\\d+(\\s?\\d*)*([.,]\\d+)?)\\s*([кК][вВ]\\.?\\s?[мМ]\\.?|[гГ][аА]\\.?|[мМ]²)", RegexOptions.IgnoreCase);
                if (foundBuildingsTest.IsMatch(offer.Description))
                {
                    var buildingFoundRes = foundBuildingsTest.Match(offer.Description);
                    if (buildingFoundRes.Success)
                    {
                        var reg1 = new Regex("[\\s:=_-]*(\\d+(\\s?\\d*)*([.,]\\d+)?)\\s*([гГ][аА]\\.?)", RegexOptions.IgnoreCase);
                        var reg1Res = reg1.Match(buildingFoundRes.Value);
                        if (reg1Res.Success)
                        {
                            var reg2 = new Regex("(\\d+(\\s?\\d*)*([.,]\\d+)?)", RegexOptions.IgnoreCase);
                            var reg2Res = reg2.Match(reg1Res.Value);
                            if (reg2Res.Success)
                            {
                                var buff = reg2Res.Value;
                                Regex.Replace(buff, "\\s+", "");
                                data.TotalBuildingArea = float.Parse(buff);
                            }
                        }
                        var res3 = Regex.Match(buildingFoundRes.Value, "[\\s:=_-]*(\\d+(\\s?\\d*)*([.,]\\d+)?)\\s*([кК][вВ]\\.?\\s?[мМ]\\.?|[мМ]²)", RegexOptions.IgnoreCase);
                        if (res3.Success)
                        {
                            var res4 = Regex.Match(res3.Value, "(\\d+(\\s?\\d*)*([.,]\\d+)?)", RegexOptions.IgnoreCase);
                            if (res4.Success)
                            {
                                data.TotalBuildingArea = float.Parse(Regex.Replace(res4.Value, "\\s+", ""));
                            }
                        }
                    }
                }

                //| Наличие зданий/строений под снос
                if (Regex.IsMatch(offer.Description, "(аварийное|состояние)\\s(состояние|аварийное)", RegexOptions.IgnoreCase))
                    data.PresenceOfBuildingsStructuresForDemolition = "Да";

                //| Наличие ж/д на участке
                if (Regex.IsMatch(offer.Description, "\\s(железнодорожны(й|ми)|жд|ж\\.д|ж\\/д).{1,10}тупик", RegexOptions.IgnoreCase))
                    data.HaveTrainStation = "Да";

                //| Наличие газоснабжения
                if(
                    Regex.IsMatch(offer.Description, "развитие газообеспечение|возможна газификация|работа.{1,10}по.{1,10}протягиванию.{1,25}газа", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "Газ.{1,35}с возможностью подключения|[тТ]очки подключения [гГ]азоснабжения", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "возможности присоединения.{1,100}газ|нет газа|отсутствует газ", RegexOptions.IgnoreCase)
                )
                {
                    data.AvailabilityOfGasSupply = "Нет";
                } else if (
                    Regex.IsMatch(offer.Description, "[гГ]азоснабжение|[гГ]азовая котельная|[гГ]азовая подстанция", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[гГ]аз (по|на) границе|[гГ]азопроводы?", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[кК]оммуникаци(и|ями)[\\s:=-]+.{1,150}газ[\\s.,]|Межрегионгаз|Мосгаз|Газпром", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[гГ]аз высокого давления|[мМ]агистральный газ", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[еЕ]сть газ|[гГ]аз.{1,15}\\d+(\\s?\\d*)*([.,]\\d+)?метр", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "имеются коммуникации.{1,65}газ|все коммуникации:.{1,65}газ|заведено.{1,65}газ", RegexOptions.IgnoreCase)
                )
                {
                    data.AvailabilityOfGasSupply = "Да";
                }

                //| Наличие электроснабжения
                if (Regex.IsMatch(offer.Description, "([вВ]озможно.{1,20}подключени[ея]|условие для|возможност[ьи] подключени[ея]).{1,60}(электросет(ям|и|ей)|электричеств[оау]|электроэнергии|эл-гии|эл-ии|эл-во|[эЭ]лектро сет(ям|и|ей))", RegexOptions.IgnoreCase))
                {
                    data.AvailabilityOfPowerSupply = "Нет";
                }
                else if (
                    Regex.IsMatch(offer.Description, "([эЭ]лектричество|сети|[эЭ]лектроэнергия).{1,10}\\d+(\\s?\\d*)*([.,]\\d+)?.{1,5}[кК][вВ][тТ]", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "([эЭ]лектричество|сети|[эЭ]лектроэнергия).{1,10}\\d+(\\s?\\d*)*([.,]\\d+)?.{1,5}[кК][вВ][тТ]", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "([пП]одведен[оы]|[зЗ]аведен[оы]|имеется) ([эЭ]лектричество|[эЭ]л-во)", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "есть доступ к электроэнергии", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "([эЭ]лектрическая мощность|[оО]бщая мощность|[мМ]ощность электричества|[зЗ]аведено электричество с мощностью|[эЭ]лектроэнергия|[вВ]ыделенная мощность|[вВ]ыделенная лектрическая мощность|[еЕ]диновременная мощность)[\\s,]*(разрешенная мощность|\\(РУ\\)|электроснабжения)?([а-яА-Я)(]*)([\\s:=-]*)(\\d+(\\s?\\d*)*[.,]?\\d*\\s?[кКмМгГ][вВ][тТ])", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "[эЭ]лектроснабжени[ея].{1,10}\\d*.{1,10}[кК][вВ][аА]", RegexOptions.IgnoreCase)
                )
                {
                    data.AvailabilityOfPowerSupply = "Да";
                }

                //| Наличие ИРД (разрешение на строительство)
                if (Regex.IsMatch(offer.Description, "(ГПЗУ по запросу|ГПЗУ при подготовке)", RegexOptions.IgnoreCase))
                {
                    data.BuildingPermit = "По запросу или при подготовке";
                } else if (
                    Regex.IsMatch(offer.Description, "(под редевелопмент|под строительство|проект реновации|проект строительства|ГПЗУ|архитектурный проект)", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "(получен[ыо]?|выдан[ыо]?|есть|[иИ]меется|в наличии)[\\s:=.,-]+ГПЗУ", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "с (получе|выда)нным[\\s:=.,-]+ГПЗУ", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "ГПЗУ на строительство", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "расширенное ГПЗУ", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "выдан.{1,25}ГПЗУ", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "ГПЗУ.{1,25}получен[ыо]", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "ГПЗУ:", RegexOptions.IgnoreCase) ||
                    Regex.IsMatch(offer.Description, "градостроительн(ый|ая)\\s*(план|документация)[\\s,.:\\\\\\/]", RegexOptions.IgnoreCase)
                )
                {
                    data.BuildingPermit = "Да";
                }

                //| Комментарии (Наличие ИРД)
                if (Regex.IsMatch(offer.Description, "не(попадает в)? КРТ", RegexOptions.IgnoreCase))
                    data.BuildingPermitComments = "Не попадает в зону КРТ";
                else if (Regex.IsMatch(offer.Description, "попадает.{1,50}КРТ|[кК]омплексное развитие территорий", RegexOptions.IgnoreCase))
                    data.BuildingPermitComments = "Попадает в зону КРТ";

                //| Проект планировки территории
                if (Regex.IsMatch(offer.Description, "проект.*\\s[пП]ланировк[иа]?", RegexOptions.IgnoreCase))
                    data.TerritoryPlanningProject = "Да";

                //| Исходно-разрешительная документация
                if (Regex.IsMatch(offer.Description, "(Получена|есть|имеется|включая|включена|присутствует|в наруках|в наличии).*разрешительная.*документ", RegexOptions.IgnoreCase))
                    data.InitialPermitDocumentation = "Да";

                //................
                //................
            }

            //| Состояние здания
            data.StateBuild = null;

            //| Уровень отделки
            data.FinishLevel = null;

            //| Площадь подвала, кв. м
            data.BasementArea = null;

            //| Площадь цоколя, кв. м
            data.AreaGroundFloor = null;

            //| Площадь помещений выше первого этажа, кв. м
            data.AreaPremisesHigherFirstFloor = null;

            //| Площадь первого этажа, кв. м
            data.AreaFirstFloor = null;

            //| Коммунальные платежи включены
            data.CommunalPaymentsInclude = null;

            //| Площадь земли, кв. м
            if (offer.Land != null && offer.Land.AreaUnitType != null && offer.Land.Area != null)
            {
                float buffArea = float.Parse(Regex.Replace(offer.Land.Area, "\\.", ","));
                if (offer.Land.AreaUnitType == "hectare")
                    data.LandArea = buffArea * 10000;
                else if (offer.Land.AreaUnitType == "sotka")
                    data.LandArea = buffArea * 10000;
            }

            //| Площадь паркинга, кв. м
            data.PrkingArea = null;

            //| Площадь машиноместа, кв.м
            data.ParkingElementArea = null;

            //| Тип входа
            data.HavingSeparateEntranceType = null;

            //| Линия расположения объекта
            data.ObjectLocationLine = null;

            //| Высота потолков, м
            data.CeilingHeight = null;

            //| Состояние помещения
            data.StateOfRepair = null;
         
            //| Планировка
            data.Layout = null;

            //| Высота гаража, м.
            data.GarageHeight = null;

            data.PermittedUse = null;

            //| Расположение относительно автомагистрали
            data.DistanceToMotorway = null;

            return data;
        }

        public CompleteFields TranslateFromAvito(string any)
        {
            //.........
            return new CompleteFields();
            //.........
        }

        public CompleteFields TranslateFromAny(string any)
        {
            //.........
            return new CompleteFields();
            //.........
        }
    }
}
