namespace Marketplace.App.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; } = "Yellow";

        public string PictureUrl { get; set; }

        public decimal Total => Quantity * Price;
    }
}
