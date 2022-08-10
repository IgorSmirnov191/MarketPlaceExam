using System.ComponentModel.DataAnnotations;

namespace MarketPlaceExam.Data.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public IList<CartItem> CartItems { get; set; } = new List<CartItem>();

        public override string ToString()
        {
            return $"Id{Id}, UserId: {UserId}";
        }
    }
}