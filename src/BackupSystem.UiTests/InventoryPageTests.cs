namespace BackupSystem.UiTests;

public class InventoryPageTests : BasePageTests
{
    [Fact]
    public async Task AddToCart_WhenProductAdded_ShouldUpdateCartBadge()
    {
        // Arrange
        var inventoryPage = new InventoryPage(page);

        // Act
        await inventoryPage.AddBackpackToCart();

        // Assert
        Assert.Equal(1, await inventoryPage.CartItemCount());
    }
}
