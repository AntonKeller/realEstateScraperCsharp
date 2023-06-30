﻿using Microsoft.Playwright;
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

    class CitiyStructure : CianTerritorialUnit
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

        public async Task<CitiyStructure> GetCianCitiesByRegionId(int regionId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathCities);
            var respArrDistr = JsonConvert.DeserializeObject<CitiyStructure[]>(fileStr);
            return Array.Find<CitiyStructure>(respArrDistr, (e) => e.Region_id == regionId);
        }

        public async Task<DistrictStructure> GetCianDistrictsByCityId(int cityId, IPage page = null)
        {
            string fileStr = await ReadJsonFile(PathDistricts);
            var respArrDistr = JsonConvert.DeserializeObject<DistrictStructure[]>(fileStr);
            return Array.Find<DistrictStructure>(respArrDistr, (e) => e.City_id == cityId);
        }

        public async Task<LinksGeneration> PageLinksGenerator(IPage page, string baseUrl)
        {
            if (IsNull(page, baseUrl)) return null;
            var scripts = new Dictionary<string, string>
            {
                ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.totalOffers",
                ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.totalOffers",
            };

            await page.GotoAsync(baseUrl + "&p=1");
            string fieldName = await WhatIsFieldNameSerp(page, baseUrl);
            if (!scripts.ContainsKey(fieldName)) return null;
            var totalOffers = await page.EvaluateAsync<int?>(scripts[fieldName]);
            if (totalOffers == null) return null;

            //| Определяем кол-во страниц
            var maxPages = (int)Math.Floor((decimal)totalOffers / 28);
            maxPages = maxPages > 54 ? 54 : maxPages;

            //| Генерируем страницы
            var links = new List<string>();
            for (int i = 0; i <= maxPages; i++)
                links.Add($"{baseUrl}&p={i}");

            //await page.GotoAsync(baseUrl + "&p=1", PAGE_OPTIONS);
            // настройки опции страницы (page options)

            return new LinksGeneration(totalOffers, maxPages, links);
        }

        private bool IsNull(IPage page, string url) => page == null || url == null;

        private async Task<string> WhatIsFieldNameSerp(IPage page, string url)
        {
            if (IsNull(page, url)) return null;
            await page.GotoAsync(url);
            var script = "Object.keys(window._cianConfig).find(key => key.toLowerCase().indexOf(\"serp\") !== -1)";
            return await page.EvaluateAsync<string>(script);
        }

        public async Task<CianOffer[]> LoadOffersFromPage(IPage page, string url)
        {
            var scripts = new Dictionary<string, string>
            {
                ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.offers",
                ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.offers",
            };
            if (IsNull(page, url)) return null;
            string fieldName = await WhatIsFieldNameSerp(page, url);
            if (!scripts.ContainsKey(fieldName)) return null;
            return await page.EvaluateAsync<CianOffer[]>(scripts[fieldName]);
        }

        private DistrictStructure SearchDistrictInObject(DistrictStructure inObj, string name, string type)
        {
            if (
                Regex.IsMatch(inObj.Name, name, RegexOptions.IgnoreCase) &&
                Regex.IsMatch(inObj.Type, type, RegexOptions.IgnoreCase)
            ) return inObj;
            if (inObj?.Childs?.Length > 0)
            {
                var res = SearchDistrictInArray(inObj.Childs, name, type);
                if (res != null) return res;
            }
            return null;
        }

        public DistrictStructure SearchDistrictInArray(DistrictStructure[] inObjArr, string name, string type)
        {
            for (int i = 0; i < inObjArr.Length; i++)
            {
                var res = SearchDistrictInObject(inObjArr[i], name, type);
                if (res != null) return res;
            }
            return null;
        }
        
        public string getMskOkrugShort(string okrug)
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
