using Microsoft.Playwright;

namespace BackupSystem.UiTests.PagesTests;

// Klasa bazowa do przeprowadzania testów
public abstract class BasePageTests : IAsyncLifetime
{
    protected virtual string BaseUrl => "https://example.com/";

    private IPlaywright playwright;
    protected IBrowser browser;
    protected IPage page;
    protected IBrowserContext context;

    public async Task InitializeAsync()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, 
            SlowMo = 800 });

        context = await browser.NewContextAsync();
        page = await browser.NewPageAsync();

        await page.GotoAsync(BaseUrl);
    }

    public async Task DisposeAsync()
    {
        playwright.Dispose();

        await browser.DisposeAsync();
    }   
}
