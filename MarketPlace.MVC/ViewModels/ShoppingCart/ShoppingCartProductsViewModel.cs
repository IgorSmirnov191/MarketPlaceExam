namespace Marketplace.App.ViewModels.ShoppingCart
{
    public class CartViewModel
    {
        public IList<ShoppingCartViewModel> Products { get; set; }

        public decimal TotalProductsCost => Products.Select(x => x.Total).Sum();

    }
}