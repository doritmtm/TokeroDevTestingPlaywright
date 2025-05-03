using Microsoft.Playwright;
using System.Globalization;
using System.Resources;

namespace TokeroDevTestingPlaywright
{
    public static class TestHelper
    {
        public static ResourceManager ResourceManager { get; } = new ResourceManager(typeof(Resources));

        public static async Task<IPage> InitializePage(IBrowserType browserType)
        {
            IBrowser browser = await browserType.LaunchAsync();
            IBrowserContext browserContext = await browser.NewContextAsync();
            IPage page = await browserContext.NewPageAsync();
            return page;
        }

        public static async Task RunOnAllBrowsersAllLanguages(Func<IPage, string, Task> asyncTest, TestContext testContext, string testName)
        {
            testContext.WriteLine($"Running {testName} test");

            IPlaywright playwright = await Playwright.CreateAsync();

            IPage chromiumPage = await InitializePage(playwright.Chromium);
            foreach (string language in StaticSettings.SupportedLanguages)
            {
                testContext.WriteLine($"    Running current test for {language} language on Chromium");
                await asyncTest(chromiumPage, language);
            }

            IPage firefoxPage = await InitializePage(playwright.Firefox);
            foreach (string language in StaticSettings.SupportedLanguages)
            {
                testContext.WriteLine($"    Running current test for {language} language on Firefox");
                await asyncTest(firefoxPage, language);
            }

            IPage webkitPage = await InitializePage(playwright.Webkit);
            foreach (string language in StaticSettings.SupportedLanguages)
            {
                testContext.WriteLine($"    Running current test for {language} language on Webkit");
                await asyncTest(webkitPage, language);
            }

            testContext.WriteLine($"Run {testName} test successful");
        }

        public static string GetLocalizedString(string nameID, string language)
        {
            return ResourceManager.GetString(nameID, new CultureInfo(language)) ?? throw new Exception($"Localized string '{nameID}' not found for language '{language}'.");
        }
    }
}
