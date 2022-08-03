using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        
        [Required]
        [MaxLength(50)]
        public string PayName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayCity { get; set; }

        [Required]
        [MaxLength(8)]
        public string PayZipCode { get; set; }
     
        [MaxLength(50)]
        public string PayPhone { get; set; }

        [MaxLength(50)]
        public string? PayEmail { get; set; }

        [MaxLength(50)]
        public string PayType { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShipAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShipCity { get; set; }

        [Required]
        [MaxLength(8)]
        public string ShipZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ShipPhone { get; set; }

        [MaxLength(50)]
        public string ShipEmail { get; set; }

        [Required]
        public decimal Total { get; set; } = 0;
        public string? AuthToken { get; set; }

        public List<Cart> Carts { get; set; }
        public override string ToString()
        {
            return $"Id{Id}, UserId {UserId}, PayName: {PayName}, " +
                $"PayAddress: {PayAddress}, PayCity: {PayCity}, PayZipCode: {PayZipCode}, " +
                $"PayPhone: {PayPhone}, PayEmail: {PayEmail}" +
                $"ShipAddress: {ShipAddress}, ShipCity: {ShipCity}, ShipZipCode: {ShipZipCode}," +
                $"ShipPhone: {ShipPhone}, ShipEmail: {ShipEmail}, Total: €{Total}";
        }
    }
}
