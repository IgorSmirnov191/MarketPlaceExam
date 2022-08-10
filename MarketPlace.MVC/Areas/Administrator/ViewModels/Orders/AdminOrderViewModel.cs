using MarketPlaceExam.Data.Entities;
using System;

namespace Marketplace.App.Areas.Administrator.ViewModels.Orders
{
    public class AdminOrderViewModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime OrderDate { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
