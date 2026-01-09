using Microsoft.Playwright;

namespace BackupSystem.UiTests;


// Wzorzec: Page Object Model

public class LoginPage
{
    private readonly IPage page;

    public LoginPage(IPage page)
    {
        this.page = page;
    }

    private const string UsernameFieldSelector = "#user-name";
    private const string PasswordFieldSelector = "Password";
    private const string LoginButtonSelector = "#login-button";
    private const string ErrorSelector = ".error-message-container.error";

    public async Task LoginAs(string username, string password)
    {
        await page.FillAsync(UsernameFieldSelector, username);
        await page.FillAsync(PasswordFieldSelector, password);
        await page.ClickAsync(LoginButtonSelector);
    }

    public async Task<bool> IsLogged()
    {
        await page.WaitForURLAsync("**/inventory.html");
        return page.Url.EndsWith("inventory.html");
    }

    public async Task<bool> HasError()
    {
        await page.WaitForSelectorAsync(ErrorSelector);
        return await page.IsVisibleAsync(ErrorSelector);
    }
}


