using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.UiTests.Tests;

public class InventoryTests
{
    [Fact]
    public async Task AddToCart_WhenOneProduct_ShowCartBadgeWithOneProduct()
    {
        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");

        // login
        await page.FillAsync("#user-name", "standard_user"); // # - selektor do id 
        await page.FillAsync("#password", "secret_sauce");
        await page.ClickAsync("#login-button");

        // Act
        await page.ClickAsync("#add-to-cart-sauce-labs-backpack");

        // Assert        

        Assert.Equal("1", await page.InnerTextAsync("[data-test='shopping-cart-badge']")); // data-test
        // Assert.Equal("1", await page.InnerTextAsync(".shopping_cart_link")); // . - po klasie css
    }

    [Fact]
    public async Task AddToCart_WhenTwoProductOrders_ShowCartBadgeWithTwoProduct()
    {
        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");

        // login
        await page.FillAsync("#user-name", "standard_user"); // # - selektor do id 
        await page.FillAsync("#password", "secret_sauce");
        await page.ClickAsync("#login-button");

        // Act
        await page.ClickAsync("#add-to-cart-sauce-labs-backpack");
        await page.ClickAsync("#add-to-cart-sauce-labs-bike-light");

        // Assert        

        Assert.Equal("2", await page.InnerTextAsync("[data-test='shopping-cart-badge']")); // data-test        
    }

    [Fact]
    public async Task RemoveFromCart_WhenProductRemoved_CartBadgeRemoved()
    {
        // Arrange
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");

        // login
        await page.FillAsync("#user-name", "standard_user"); // # - selektor do id 
        await page.FillAsync("#password", "secret_sauce");
        await page.ClickAsync("#login-button");

        // Act
        await page.ClickAsync("#add-to-cart-sauce-labs-backpack");
        await page.ClickAsync("#remove-sauce-labs-backpack");

        // Assert        
        Assert.False(await page.IsVisibleAsync("[data-test='shopping-cart-badge']"));
    }

}
