namespace MarketPlace.MVC.ViewModels.Orders
{
    public class MyOrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public int CartId { get; set; }
        public int PaymentId { get; set; }
        public int Quantity { get; set; }

    }
}
