using MarketPlaceExam.Data.Entities;
using System;

namespace Marketplace.App.ViewModels.Orders
{
    public class MyOrderViewModel
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public int CartId { get; set; }
        public int PaymentId { get; set; }
      
    }
}
