using MarketPlaceExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Model
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public string PayUserName { get; set; }
        public string PayAddress { get; set; }
        public string PayCity { get; set; }
              
        public string PayZipCode { get; set; }

        public string PayPhoneNumber { get; set; }

        public string? PayEmail { get; set; }

        public string PayType { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipZipCode { get; set; }

        public string? ShipPhoneNumber { get; set; }

        public string ShipEmail { get; set; }

        [Required]
        public decimal Total { get; set; } = 0;
       
        public List<Cart> Carts { get; set; }
    }
}
