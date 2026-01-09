using BackupSystem.UiTests.Pages;

namespace BackupSystem.UiTests.PagesTests;

public class LoginPageTests : SauceDemoPageTests
{
    // Arrange
    private LoginPage loginPage => new LoginPage(page);

    [Fact]
    public async Task Login_WithValidCredentials_ShowInventoryPage()
    {
        // Arrange
        var inventoryPage = new InventoryPage(page);

        // Act
        await loginPage.LoginAs("standard_user", "secret_sauce");

        // Assert
        Assert.True(await inventoryPage.IsDisplayed());
    }


    [Fact]
    public async Task Login_WithInvalidCredentials_ShowError()
    {
        // Act
        await loginPage.LoginAs("standard_user", "wrong_password");

        // Assert
        Assert.True(await loginPage.HasError());
    }
}


