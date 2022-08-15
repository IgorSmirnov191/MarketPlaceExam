namespace MarketPlace.MVC.ViewModels.ShoppingCart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public IList<ShoppingCartViewModel> Products { get; set; }

        public decimal TotalProductsCost => Products.Select(x => x.Total).Sum();

    }
}