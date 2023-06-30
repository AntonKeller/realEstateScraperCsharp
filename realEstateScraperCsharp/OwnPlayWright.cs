using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightExtraSharp.Models;
using PlaywrightExtraSharp;
using PlaywrightExtraSharp.Plugins.ExtraStealth;
using Newtonsoft.Json.Linq;
using Esprima.Ast;
using System.Security.Policy;

namespace realEstateScraperCsharp
{

    class Student
    {
        public string firstName;
        public string middleName;
        public string lastName;
        public int age;
        public double height;
        public double width;
    }

    internal class MyPlaywrightExtra
    {
        public static async Task<PlaywrightExtra> OpenBrowser(bool headless = false)
        {
            var playwright = new PlaywrightExtra(BrowserTypeEnum.Chromium);
            playwright.Install();
            playwright.Use(new StealthExtraPlugin());
            await playwright.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = headless
            });
            return playwright;
        }
    }
}
