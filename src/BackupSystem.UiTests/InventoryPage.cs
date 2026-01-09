using Microsoft.Playwright;

namespace BackupSystem.UiTests;

public class InventoryPage
{
    private readonly IPage page;

    public InventoryPage(IPage page)
    {
        this.page = page;
    }

    public async Task<int> CartItemCount()
    {
        return await GetCartBadgeCount();
    }

    public async Task AddBackpackToCart()
    {
        await page.ClickAsync("[data-test='add-to-cart-sauce-labs-backpack']");
    }

    private async Task<int> GetCartBadgeCount()
    {
        if (!await page.IsVisibleAsync(".shopping_cart_badge"))
            return 0;

        var text = await page.InnerTextAsync(".shopping_cart_badge");
        return int.Parse(text);
    }
}