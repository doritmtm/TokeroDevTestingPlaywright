using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright.Tests
{
    [TestClass]
    [DoNotParallelize]
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
                    await TestHelper.WaitForFullPageLoad(page);
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

                    await TestHelper.WaitForFullPageLoad(page);

                    await TestHelper.AcceptCookies(page);

                    ILocator policiesLink = page.Locator($"a[href='/{language}/policies/']");
                    await Expect(policiesLink).ToBeVisibleAsync();

                    await policiesLink.ScrollIntoViewIfNeededAsync();
                    await policiesLink.ClickAsync();

                    await page.WaitForURLAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies/");
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

                    await TestHelper.WaitForFullPageLoad(page);

                    await TestHelper.AcceptCookies(page);

                    ILocator content = page.Locator("[class*=pageContent]");

                    ILocator termsOfService = content.Locator($"a[href='/{language}/policies/terms-of-service/']");
                    await Expect(termsOfService).ToBeVisibleAsync();

                    ILocator privacy = content.Locator($"a[href='/{language}/policies/privacy/']");
                    await Expect(privacy).ToBeVisibleAsync();

                    ILocator fees = content.Locator($"a[href='/{language}/policies/fees/']");
                    await Expect(fees).ToBeVisibleAsync();

                    ILocator cookies = content.Locator($"a[href='/{language}/policies/cookies/']");
                    await Expect(cookies).ToBeVisibleAsync();

                    ILocator kyc = content.Locator($"a[href='/{language}/policies/kyc/']");
                    await Expect(kyc).ToBeVisibleAsync();

                    ILocator referrals = content.Locator($"a[href='/{language}/referral-program/']");
                    await Expect(referrals).ToBeVisibleAsync();

                    ILocator answeringTimes = content.Locator($"a[href='/{language}/policies/answering-times/']");
                    await Expect(answeringTimes).ToBeVisibleAsync();

                    ILocator minimumsOptions = content.Locator($"a[href='/{language}/policies/minimums-and-options/']");
                    await Expect(minimumsOptions).ToBeVisibleAsync();

                    ILocator gdpr = content.Locator($"a[href='/{language}/policies/gdpr/']");
                    await Expect(gdpr).ToBeVisibleAsync();

                    ILocator amlCountries = content.Locator($"a[href='/{language}/policies/aml-countries/']");
                    await Expect(amlCountries).ToBeVisibleAsync();
                },
                TestContext,
                "Page_List_Links",
                StaticSettings.MaxTimeToLoadPage * 3 / 2
            );
        }

        [TestMethod]
        public async Task Page_List_Names()
        {
            await TestHelper.RunOnAllBrowsersAllLanguages
            (
                async (page, language) =>
                {
                    await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies");

                    await TestHelper.WaitForFullPageLoad(page);

                    await TestHelper.AcceptCookies(page);

                    ILocator content = page.Locator("[class*=pageContent]");

                    ILocator termsOfService = content.Locator($"a[href='/{language}/policies/terms-of-service/']");
                    await Expect(termsOfService.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("TermsAndConditions", language));

                    ILocator privacy = content.Locator($"a[href='/{language}/policies/privacy/']");
                    await Expect(privacy.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("Privacy", language));

                    ILocator fees = content.Locator($"a[href='/{language}/policies/fees/']");
                    await Expect(fees.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("Fees", language));

                    ILocator cookies = content.Locator($"a[href='/{language}/policies/cookies/']");
                    await Expect(cookies.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("Cookies", language));

                    ILocator kyc = content.Locator($"a[href='/{language}/policies/kyc/']");
                    await Expect(kyc.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("KYC", language));

                    ILocator referrals = content.Locator($"a[href='/{language}/referral-program/']");
                    await Expect(referrals.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("Referrals", language));

                    ILocator answeringTimes = content.Locator($"a[href='/{language}/policies/answering-times/']");
                    await Expect(answeringTimes.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("RequestAnsweringProcessingTimes", language));

                    ILocator minimumsOptions = content.Locator($"a[href='/{language}/policies/minimums-and-options/']");
                    await Expect(minimumsOptions.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("MinimumsAndOptions", language));

                    ILocator gdpr = content.Locator($"a[href='/{language}/policies/gdpr/']");
                    await Expect(gdpr.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("GDPR", language));

                    ILocator amlCountries = content.Locator($"a[href='/{language}/policies/aml-countries/']");
                    await Expect(amlCountries.Locator(":scope > *").First).ToContainTextAsync(TestHelper.GetLocalizedString("CountriesListForAMLRiskAssessment", language));
                },
                TestContext,
                "Page_List_Names",
                StaticSettings.MaxTimeToLoadPage * 3 / 2
            );
        }

        //This is expected to fail due to language bug on de language
        //TOKERO Richtlinien und Regeln != TOKERO kasutustingimused ja reeglid
        [TestCategory("Failing")]
        [TestMethod]
        public async Task Page_List_Title()
        {
            await TestHelper.RunOnAllBrowsersAllLanguages
            (
                async (page, language) =>
                {
                    await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/{language}/policies");

                    await TestHelper.WaitForFullPageLoad(page);

                    await TestHelper.AcceptCookies(page);

                    ILocator content = page.Locator("[class*=pageContent]");

                    ILocator listTitle = content.Locator("h1.mb-5.text-center");
                    await Expect(listTitle).ToContainTextAsync(TestHelper.GetLocalizedString("PoliciesListPageTitle", language));
                },
                TestContext,
                "Page_List_Title",
                StaticSettings.MaxTimeToLoadPage * 3 / 2
            );
        }
    }
}
