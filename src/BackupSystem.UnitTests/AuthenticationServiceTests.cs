using BackupSystem.Core;

namespace BackupSystem.UnitTests;

public class AuthenticationServiceTests
{
    [Theory]
    [InlineData("john", "password", true)]
    [InlineData("john", "wrong_password", false)]
    [InlineData("", "", false)]
    public void IsAuthenticated_WhenCalled_ReturnsExpected(string login, string password, bool expected)
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();

        // Act
        authenticationService.Login(login, password);

        // Assert
        Assert.Equal(expected, authenticationService.IsAuthenticated);
    }
}