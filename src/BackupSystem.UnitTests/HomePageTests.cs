using BackupSystem.Core;
using BackupSystem.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.UnitTests;

public class HomePageTests
{
    [Theory]
    [InlineData("john", "password", true)]
    [InlineData("john", "wrong_password", false)]
    [InlineData("", "", false)]
    public void IsAuthorized_WhenCalled_ReturnsExpected(string login, string password, bool expected)
    {
        // Arrange
        AuthenticationService authenticationService = new AuthenticationService();
        HomePage homePage = new HomePage(authenticationService);

        // Act
        authenticationService.Login(login, password);

        // Assert
        Assert.Equal(expected, homePage.IsAuthorized);
    }   
}
