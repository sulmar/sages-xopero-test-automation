namespace BackupSystem.Core.Pages;

public class HomePage
{
    private AuthenticationService authenticationService;

    public HomePage(AuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    public bool IsAuthorized // Czy uzytkownik ma dostep do stron?
    {
        get
        {
            return authenticationService.IsAuthenticated && authenticationService.IsInRole("admin");
            // zalogowany uzytkownik posiadajacy role administratora
        }
    }

}
