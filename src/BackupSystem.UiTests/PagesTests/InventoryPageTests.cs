using BackupSystem.UiTests.Domain;
using BackupSystem.UiTests.Pages;

namespace BackupSystem.UiTests.PagesTests;


public class InventoryPageTests : SauceDemoPageTests
{
    private InventoryPage inventoryPage => new InventoryPage(page);
    private LoginPage loginPage => new LoginPage(page);

    [Fact]
    public async Task AddToCart_WhenProductAdded_CartWithOneProduct()
    {
        // Arrange        
        await loginPage.LoginAsStandardUser();

        // Act
        await inventoryPage.AddToCart(Product.Backpack);

        // Assert
        Assert.Equal(1, await inventoryPage.GetCartItemCountAsync());
    }

    [Fact]
    public async Task AddToCart_WhenProductAdded_CartWithTwoProducts()
    {
        // Arrange        
        await loginPage.LoginAsStandardUser();

        // Act
        await inventoryPage.AddToCart(Product.Backpack);
        await inventoryPage.AddToCart(Product.BikeLight);

        // Assert
        Assert.Equal(2, await inventoryPage.GetCartItemCountAsync());
    }


    [Theory]
    [InlineData(new[] { Product.Backpack }, 1)]
    [InlineData(new[] { Product.Backpack, Product.BikeLight }, 2)]
    public async Task AddToCart_WhenProductsAdded_CartContainsExpectedNumber(
    string[] products,
    int expectedCount)
    {
        // Arrange
        await loginPage.LoginAsStandardUser(); 

        // Act
        foreach (var product in products)
        {
            await inventoryPage.AddToCart(product);
        }

        // Assert
        Assert.Equal(expectedCount, await inventoryPage.GetCartItemCountAsync());
    }
}
