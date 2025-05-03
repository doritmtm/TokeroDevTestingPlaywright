using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright
{
    public static class TestHelper
    {
        public static async Task<IPage> InitializePage(IBrowserType browserType)
        {
            IBrowser browser = await browserType.LaunchAsync();
            IBrowserContext browserContext = await browser.NewContextAsync();
            IPage page = await browserContext.NewPageAsync();
            return page;
        }

        public static async Task RunOnAllBrowsers(Func<IPage, Task> asyncTest)
        {
            IPlaywright playwright = await Playwright.CreateAsync();

            IPage chromiumPage = await InitializePage(playwright.Chromium);
            await asyncTest(chromiumPage);

            IPage firefoxPage = await InitializePage(playwright.Firefox);
            await asyncTest(firefoxPage);

            IPage webkitPage = await InitializePage(playwright.Webkit);
            await asyncTest(webkitPage);
        }
    }
}
