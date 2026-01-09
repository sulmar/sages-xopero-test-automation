using BackupSystem.UiTests.Pages;

namespace BackupSystem.UiTests.PagesTests;

// Klasa bazowa do przeprowadzania testów na stronie https://www.saucedemo.com/
public abstract class SauceDemoPageTests : BasePageTests
{
    protected override string BaseUrl => "https://www.saucedemo.com/";

    protected InventoryPage InventoryPage => new InventoryPage(page);
    protected LoginPage LoginPage => new LoginPage(page);

}
