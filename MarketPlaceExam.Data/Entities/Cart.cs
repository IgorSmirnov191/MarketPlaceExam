using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }    
        public string? AuthToken { get; set; }
        
        //todo data annotation

        public override string ToString()
        {
            return $"Id{Id}, UserId: {UserId}, PaymentId: {PaymentId}";
        }
    }
}
