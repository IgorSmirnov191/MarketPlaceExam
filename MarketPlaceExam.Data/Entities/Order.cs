using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, UserId: {UserId}, Date of Order: {OrderDate}," +
                $"CartId: {CartId}";
        }
    }
}
