using Microsoft.Playwright;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace realEstateScraperCsharp.Modules.API
{

    class DSDirection
    {
        public string Code;
        public string Name;
    }

    class DistrictStructure
    {
        public int Id;
        public string Name;
        public string Type;
        public DistrictStructure[] Childs;
        public DSDirection Direction;
    }

    internal class CianAPI
    {


        private Dictionary<string, string> FrontendSerpFields = new Dictionary<string, string>
        {
            ["frontend-serp"] = "() => window._cianConfig['frontend-serp'].find(item => item.key === 'initialState').value.results.offers",
            ["legacy-commercial-serp-frontend"] = "() => window._cianConfig['legacy-commercial-serp-frontend'].find(item => item.key === 'initialState').value.results.offers",
        };

        public async Task<CianOffer[]> LoadOffersFromPage(IPage page, string url)
        {
            if(page == null || url == null) return null;
            await page.GotoAsync(url);
            string fieldName = await page.EvaluateAsync<string>("Object.keys(window._cianConfig).find(key => key.toLowerCase().indexOf(\"serp\") !== -1)");
            if (!FrontendSerpFields.ContainsKey(fieldName)) return null;
            var script = FrontendSerpFields[fieldName];
            var response = await page.EvaluateAsync(script);
            var offers = JsonConvert.DeserializeObject<CianOffer[]>(response.ToString());
            return offers;
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
