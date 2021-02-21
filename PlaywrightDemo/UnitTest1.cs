using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PlaywrightSharp;
using Xunit;

namespace PlaywrightDemo
{
    public class UnitTest1
    {
        [Fact]
        public async Task SearchForUsOnBing()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(headless:false);
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://www.bing.com");

            await page.FillAsync("#sb_form_q", "dotnetdevs.at");

            await page.PressAsync("#sb_form_q", "Enter");

            await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}
