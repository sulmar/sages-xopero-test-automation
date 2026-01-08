namespace BackupSystem.Core.Pages;

public class LoginPage
{
    private AuthenticationService authenticationService;

    public LoginPage(AuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    public void Login(string login, string password)
    {
        authenticationService.Login(login, password);
    }
}
