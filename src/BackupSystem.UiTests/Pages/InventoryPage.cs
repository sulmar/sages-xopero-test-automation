using Microsoft.Playwright;

namespace BackupSystem.UiTests.Pages;

public class InventoryPage : BasePage
{
    private const string ShoppingCartBadgeSelector = ".shopping_cart_badge";
    private const string InventoryContainer = ".inventory_list";

    public InventoryPage(IPage page) : base(page)
    {
    }


    public async Task<int> GetCartItemCountAsync()
    {
        return await GetCartBadgeCount();
    }

    private string AddToCartSelector(string productSlug) => $"[data-test='add-to-cart-sauce-labs-{productSlug}']";
    public async Task AddToCart(string productName) => await page.ClickAsync(AddToCartSelector(productName));

    private async Task<int> GetCartBadgeCount()
    {
        if (!await page.IsVisibleAsync(ShoppingCartBadgeSelector))
            return 0;

        var text = await page.InnerTextAsync(ShoppingCartBadgeSelector);
        return int.Parse(text);
    }

    public async Task<bool> IsDisplayed()
    {
        return await page.Locator(InventoryContainer).IsVisibleAsync();
    }
}