using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright.Tests
{
    [TestClass]
    public class PoliciesListTests : PlaywrightTest
    {
        [TestMethod]
        public async Task Page_Title()
        {
            await TestHelper.RunOnAllBrowsers(async (page) =>
            {
                await page.GotoAsync($"{StaticSettings.MainWebsiteUrl}/en/policies");
                await Expect(page).ToHaveTitleAsync($"TOKERO policies and rules | {StaticSettings.Company}");
            });
        }
    }
}
