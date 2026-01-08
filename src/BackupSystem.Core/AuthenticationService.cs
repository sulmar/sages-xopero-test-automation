namespace BackupSystem.Core;

public class AuthenticationService
{
    private const string ValidLogin = "john";
    private const string ValidPassword = "password";
    private const string Role = "admin";

    public bool IsAuthenticated { get; private set; } // Czy wiemy kim jest uzytkownik?

    

    public void Login(string login, string password)
    {
        if (login != ValidLogin || password != ValidPassword)
        {
            IsAuthenticated = false;
            return;
        }

        IsAuthenticated = true;
    }

    public bool IsInRole(string role)
    {
        return role == Role;
    }
}
