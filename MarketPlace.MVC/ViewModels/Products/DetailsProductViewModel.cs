using MarketPlaceExam.Data.Entities;

namespace MarketPlace.MVC.ViewModels.Products
{
    public class DetailsProductViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int AvailableQuantity { get; set; }
        public int Quantity { get; set; }=0;

        public string? Color { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }
    }
}
