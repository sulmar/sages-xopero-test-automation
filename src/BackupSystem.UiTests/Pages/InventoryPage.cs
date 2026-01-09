using Microsoft.Playwright;

namespace BackupSystem.UiTests.Pages;

public class InventoryPage : BasePage
{
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
        if (!await page.IsVisibleAsync(".shopping_cart_badge"))
            return 0;

        var text = await page.InnerTextAsync(".shopping_cart_badge");
        return int.Parse(text);
    }
}