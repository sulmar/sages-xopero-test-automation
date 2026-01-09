using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.UiTests.Tests;

public class LoginTests
{
    // Happy Path - zachowanie uzytkownika - po podaniu prawidlowego logina i hasla powinna sie pojawic strona 
    [Fact]
    public async Task Login_WithValidCredentials_ShowInventoryPage()
    {
        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");

        // Act
        await page.FillAsync("#user-name", "standard_user"); // # - selektor do id 
        await page.FillAsync("#password", "secret_sauce");
        await page.ClickAsync("#login-button");

        // Assert        
        await page.WaitForURLAsync("**/inventory.html"); // dopasowanie adresu URL za pomoca wzorca (global pattern)
        // ** - to wildcard, ktory oznacza dowolny ciag znakow (rowniez z ukosnikami)
    }

    // Unhappy Path - bledne haslo
    // UnHappy Path - bŁędne hasło
    [Fact]
    public async Task Login_WithInvalidPassword_DisplayError()
    {
        // Arrange
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");

        // Act
        await page.FillAsync("#user-name", "standard_user");
        await page.FillAsync("#password", "invalid_password");
        await page.ClickAsync("#login-button");

        // Assert
        await page.WaitForSelectorAsync(".error-message-container.error");
        await page.WaitForSelectorAsync("[data-test='error']"); 
        await page.WaitForSelectorAsync("//h3[@data-test='error' and text() = 'Epic sadface: Username and password do not match any user in this service']"); // XPath Selector

        Assert.True(await page.IsVisibleAsync("[data-test='error']"));
        Assert.True(await page.IsVisibleAsync(".error-message-container.error")); // 
        Assert.True(await page.IsVisibleAsync("//h3[@data-test='error' and text() = 'Epic sadface: Username and password do not match any user in this service']")); // XPath Selector



    }

}
