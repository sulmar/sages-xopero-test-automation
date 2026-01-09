using Microsoft.Playwright;
using System.Diagnostics;

namespace BackupSystem.UiTests.PagesTests;

// Klasa bazowa do przeprowadzania testów
public abstract class BasePageTests : IAsyncLifetime
{
    protected virtual string BaseUrl => "https://example.com/";

    private IPlaywright playwright;
    protected IBrowser browser;
    protected IPage page;
        
    public async Task InitializeAsync()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, 
            SlowMo = 800 });
        

        page = await browser.NewPageAsync();
        await page.GotoAsync(BaseUrl);
    }

    public async Task DisposeAsync()
    {
        playwright.Dispose();

        await browser.DisposeAsync();
    }   
}

public abstract class SauceDemoPageTests : BasePageTests
{
    protected override string BaseUrl => "https://www.saucedemo.com/";
}
