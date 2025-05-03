using Microsoft.Playwright;

namespace TokeroDevTestingPlaywright.Tests
{
    [TestClass]
    public class PoliciesListTests : PlaywrightTest
    {
        [TestMethod]
        public async Task Page_Title()
        {
            IBrowser chrome = await Playwright.Chromium.LaunchAsync();
            IBrowserContext chromeContext = await chrome.NewContextAsync();
            IPage chromePagePolicies = await chromeContext.NewPageAsync();
            await chromePagePolicies.GotoAsync($"{StaticSettings.MainWebsiteUrl}/en/policies");
            await Expect(chromePagePolicies).ToHaveTitleAsync($"TOKERO policies and rules | {StaticSettings.Company}");
        }
    }
}
