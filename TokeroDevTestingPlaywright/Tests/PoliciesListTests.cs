using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright.Tests
{
    [TestClass]
    public class PoliciesListTests : PlaywrightTest
    {
        private async Task AcceptCookies(IPage page)
        {
            ILocator cookieAccept = page.Locator("[class*=acceptCookies]");
            if (await cookieAccept.IsVisibleAsync())
            {
                await cookieAccept.ClickAsync();
            }
        }

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

                    await AcceptCookies(page);

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

        [TestMethod]
        public async Task Page_List_Links()
        {
            await TestHelper.RunOnAllBrowsersAllLanguages
            (
                async (page, language) =>
                {
                    await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies");

                    await AcceptCookies(page);

                    ILocator termsOfService = page.Locator($"a[href='/{language}/policies/terms-of-service/']");
                    await Expect(termsOfService).ToBeVisibleAsync();

                    ILocator privacy = page.Locator($"a[href='/{language}/policies/privacy/']");
                    await Expect(privacy).ToBeVisibleAsync();

                    ILocator fees = page.Locator($"a[href='/{language}/policies/fees/']");
                    await Expect(fees).ToBeVisibleAsync();

                    ILocator cookies = page.Locator($"a[href='/{language}/policies/cookies/']");
                    await Expect(cookies).ToBeVisibleAsync();

                    ILocator kyc = page.Locator($"a[href='/{language}/policies/kyc/']");
                    await Expect(kyc).ToBeVisibleAsync();

                    ILocator referrals = page.Locator($"a[href='/{language}/referral-program/']");
                    await Expect(referrals).ToBeVisibleAsync();

                    ILocator answeringTimes = page.Locator($"a[href='/{language}/policies/answering-times/']");
                    await Expect(answeringTimes).ToBeVisibleAsync();

                    ILocator minimumsOptions = page.Locator($"a[href='/{language}/policies/minimums-and-options/']");
                    await Expect(minimumsOptions).ToBeVisibleAsync();

                    ILocator gdpr = page.Locator($"a[href='/{language}/policies/gdpr/']");
                    await Expect(gdpr).ToBeVisibleAsync();

                    ILocator amlCountries = page.Locator($"a[href='/{language}/policies/aml-countries/']");
                    await Expect(amlCountries).ToBeVisibleAsync();
                },
                TestContext,
                "Page_List_Links",
                StaticSettings.MaxTimeToLoadPage * 3 / 2
            );
        }
    }
}
