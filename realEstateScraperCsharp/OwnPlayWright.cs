using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightExtraSharp.Models;
using PlaywrightExtraSharp;
using PlaywrightExtraSharp.Plugins.ExtraStealth;

namespace realEstateScraperCsharp
{
    internal class OwnPlayWright
    {
        public static async Task Main()
        {
            // Initialization plugin builder
            var playwrightExtra = new PlaywrightExtra(BrowserTypeEnum.Chromium);

            // Install browser
            playwrightExtra.Install();

            // Use stealth plugin
            playwrightExtra.Use(new StealthExtraPlugin());

            // Launch the puppeteer browser with plugins
            await playwrightExtra.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = true
            });

            // Create a new page
            var page = await playwrightExtra.NewPageAsync();
            await page.GotoAsync("https://www.cian.ru/cat.php?deal_type=sale&engine_version=2&offer_type=offices&office_type%5B0%5D=1&p=7&region=1");
            await page.ScreenshotAsync(new() { Path = "StealthScreenshot.png" });
            //await page.Close();

            /*
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });*/
        }
    }
}
