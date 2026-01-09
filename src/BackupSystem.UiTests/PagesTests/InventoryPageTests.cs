using BackupSystem.UiTests.Domain;
using BackupSystem.UiTests.Pages;

namespace BackupSystem.UiTests.PagesTests;


public class InventoryPageTests : SauceDemoPageTests
{    
    [Fact]
    public async Task AddToCart_WhenProductAdded_CartWithOneProduct()
    {
        // Arrange        
        await LoginPage.LoginAsStandardUser();

        // Act
        await InventoryPage.AddToCart(Product.Backpack);

        // Assert
        Assert.Equal(1, await InventoryPage.GetCartItemCountAsync());
    }

    [Fact]
    public async Task AddToCart_WhenProductAdded_CartWithTwoProducts()
    {
        // Arrange        
        await LoginPage.LoginAsStandardUser();

        // Act
        await InventoryPage.AddToCart(Product.Backpack);
        await InventoryPage.AddToCart(Product.BikeLight);

        // Assert
        Assert.Equal(2, await InventoryPage.GetCartItemCountAsync());
    }


    [Theory]
    [InlineData(new[] { Product.Backpack }, 1)]
    [InlineData(new[] { Product.Backpack, Product.BikeLight }, 2)]
    public async Task AddToCart_WhenProductsAdded_CartContainsExpectedNumber(
    string[] products,
    int expectedCount)
    {
        // Arrange
        await LoginPage.LoginAsStandardUser(); 

        // Act
        foreach (var product in products)
        {
            await InventoryPage.AddToCart(product);
        }

        // Assert
        Assert.Equal(expectedCount, await InventoryPage.GetCartItemCountAsync());
    }
}
