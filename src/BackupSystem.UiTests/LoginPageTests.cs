namespace BackupSystem.UiTests;

public class LoginPageTests : BasePageTests
{
    [Fact]
    public async Task Login_WithValidCredentials_ShowInventoryPage()
    {
        // Arrange
        var loginPage = new LoginPage(page);

        // Act
        await loginPage.LoginAs("standard_user", "secret_sauce");

        // Assert
        Assert.True(await loginPage.IsLogged());                
    }


    [Fact]
    public async Task Login_WithInvalidCredentials_ShowError()
    {
        // Arrange
        var loginPage = new LoginPage(page);

        // Act
        await loginPage.LoginAs("standard_user", "wrong_password");

        // Assert
        Assert.True(await loginPage.HasError());
    }
}


