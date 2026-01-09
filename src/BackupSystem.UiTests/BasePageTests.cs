using Microsoft.Playwright;
using System.Diagnostics;

namespace BackupSystem.UiTests;

// Klasa bazowa do przeprowadzania testów
public abstract class BasePageTests : IAsyncLifetime
{
    private IPlaywright playwright;
    protected IBrowser browser;
    protected IPage page;
    private IBrowserContext context;
    
    protected async Task StopVideo()
    {
        await context.CloseAsync();

        var path = await page.Video.PathAsync();

    }

    public async Task InitializeAsync()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, 
            SlowMo = 1000 });

        context = await browser.NewContextAsync(new Microsoft.Playwright.BrowserNewContextOptions
        {
            RecordVideoDir =  "videos/",
            RecordVideoSize = new Microsoft.Playwright.RecordVideoSize
            {
                Width = 1280,
                Height = 720
            }
        });

        page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");
    }

    public async Task DisposeAsync()
    {
        playwright.Dispose();

        await browser.DisposeAsync();
    }   
}


