using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright.Tests
{
    [TestClass]
    public class PoliciesListTests : PlaywrightTest
    {
        [TestMethod]
        public async Task Page_Title()
        {
            await TestHelper.RunOnAllBrowsersAllLanguages
            (
                async (page, language) =>
                {
                    await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies");
                    await Expect(page).ToHaveTitleAsync($"{TestHelper.GetLocalizedString("PoliciesListPageTitle", language)} | {StaticSettings.Company}");
                },
                TestContext,
                "Page_Title",
                StaticSettings.MaxTimeToLoadPage
            );
        }
        [TestMethod]
        public async Task Navigation_To_Page()
        {
            await TestHelper.RunOnAllBrowsersAllLanguages
            (
                async (page, language) =>
                {
                    await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/{language}");
                    ILocator cookieAccept = page.Locator("[class*=acceptCookies]");
                    if (await cookieAccept.IsVisibleAsync())
                    {
                        await cookieAccept.ClickAsync();
                    }
                    ILocator policiesLink = page.Locator($"a[href='/{language}/policies/']");
                    await Expect(policiesLink).ToBeVisibleAsync();
                    await policiesLink.ClickAsync();
                    await Expect(page).ToHaveURLAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies/");
                },
                TestContext,
                "Navigation_To_Page",
                StaticSettings.MaxTimeToLoadPage * 2
            );
        }
    }
}
