using Microsoft.Playwright;

namespace BackupSystem.UiTests.Pages;


// Wzorzec: Page Object Model

public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page)
    {
    }

    private const string UsernameFieldSelector = "#user-name";
    private const string PasswordFieldSelector = "#password";
    private const string LoginButtonSelector = "#login-button";
    private const string ErrorSelector = ".error-message-container.error";

    public async Task LoginAs(string username, string password)
    {        
        await page.FillAsync(UsernameFieldSelector, username);
        await page.FillAsync(PasswordFieldSelector, password);
        await page.ClickAsync(LoginButtonSelector);
    }

    public async Task LoginAsStandardUser()
    {
        await LoginAs("standard_user", "secret_sauce");
    }   

    public async Task<bool> HasError()
    {
        await page.WaitForSelectorAsync(ErrorSelector);

        var screenshotDir = Path.Combine(AppContext.BaseDirectory, "screenshots");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = Path.Combine(screenshotDir, "login-error.png")
        });

        return await page.IsVisibleAsync(ErrorSelector);
    }
}
