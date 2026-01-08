using BackupSystem.Core;
using BackupSystem.Core.Pages;

namespace BackupSystem.UnitTests;

public class LoginPageTests
{
    [Theory]
    [InlineData("john", "password", true)]
    [InlineData("john", "wrong_password", false)]
    [InlineData("", "", false)]
    public void IsAuthenticated_WhenCalled_ReturnsExpected(string login, string password, bool expected)
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        LoginPage loginPage = new LoginPage(authenticationService);

        // Act
        loginPage.Login(login, password);

        // Assert
        Assert.Equal(expected, authenticationService.IsAuthenticated);
    }
}