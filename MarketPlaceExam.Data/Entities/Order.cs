using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, UserId: {UserId}, Date of Order: {OrderDate}," +
                $"CartId: {CartId}";
        }
    }
}
