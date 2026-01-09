using Microsoft.Playwright;

namespace BackupSystem.UiTests.Pages;

// Klasa bazowa dla Page Object Model
public abstract class BasePage
{
    protected readonly IPage page;

    public BasePage(IPage page)
    {
        this.page = page;
    }
}
