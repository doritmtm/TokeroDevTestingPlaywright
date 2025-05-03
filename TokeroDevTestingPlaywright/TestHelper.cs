using Microsoft.Playwright;
using System.Diagnostics;
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

        public static async Task RunAllLanguagesForBrowser(Func<IPage, string, Task> asyncTest, IBrowserType browserType, TestContext testContext, string testName, long maxTimeToRunTest)
        {
            IPage page = await InitializePage(browserType);

            foreach (string language in StaticSettings.SupportedLanguages)
            {
                testContext.WriteLine($"Running {testName} test on {browserType.Name} for {language} language");
                Stopwatch stopwatch = Stopwatch.StartNew();
                await asyncTest(page, language);
                stopwatch.Stop();
                testContext.WriteLine($"Took {stopwatch.ElapsedMilliseconds} ms");
                Assert.IsTrue(stopwatch.ElapsedMilliseconds < maxTimeToRunTest, $"Test {testName} for {language} language on {browserType.Name} took too long: {stopwatch.ElapsedMilliseconds} ms. Expected less than {maxTimeToRunTest} ms.");
            }
        }

        public static async Task RunOnAllBrowsersAllLanguages(Func<IPage, string, Task> asyncTest, TestContext testContext, string testName, long maxTimeToRunTest)
        {
            IPlaywright playwright = await Playwright.CreateAsync();

            await RunAllLanguagesForBrowser(asyncTest, playwright.Chromium, testContext, testName, maxTimeToRunTest);
            await RunAllLanguagesForBrowser(asyncTest, playwright.Firefox, testContext, testName, maxTimeToRunTest);
            await RunAllLanguagesForBrowser(asyncTest, playwright.Webkit, testContext, testName, maxTimeToRunTest);
        }

        public static string GetLocalizedString(string nameID, string language)
        {
            return ResourceManager.GetString(nameID, new CultureInfo(language)) ?? throw new Exception($"Localized string '{nameID}' not found for language '{language}'.");
        }
    }
}
