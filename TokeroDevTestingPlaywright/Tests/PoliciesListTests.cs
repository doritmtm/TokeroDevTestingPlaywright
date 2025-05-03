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
    }
}
