using Microsoft.Playwright;
using System.Threading.Tasks;

namespace BackupSystem.UiTests;

public class SmokeTests
{
    [Fact]
    public async Task ExampleCom_WhenOpened_DisplayTitleExampleDomain()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://example.com/");

        string title = await page.TitleAsync();

        Assert.Equal("Example Domain", title);
    }
}
