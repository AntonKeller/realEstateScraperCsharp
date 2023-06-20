using System.Threading.Tasks;
using Microsoft.Playwright;

namespace OwnPlayWright
{
    public class Class1
    {
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });
        }
    }
}