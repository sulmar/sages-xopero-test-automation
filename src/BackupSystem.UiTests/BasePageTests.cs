using Microsoft.Playwright;

namespace BackupSystem.UiTests;

// Klasa bazowa do przeprowadzania testów
public abstract class BasePageTests : IAsyncLifetime
{
    private IPlaywright playwright;
    private IBrowser browser;
    protected IPage page;

    public async Task InitializeAsync()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");
    }

    public async Task DisposeAsync()
    {
        playwright.Dispose();

        await browser.DisposeAsync();
    }   
}


