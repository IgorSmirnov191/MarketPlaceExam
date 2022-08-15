using MarketPlaceExam.Data.Entities;

namespace MarketPlace.MVC.ViewModels.Orders
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int PaymentId { get; set; }

        public int ProductsCount { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
