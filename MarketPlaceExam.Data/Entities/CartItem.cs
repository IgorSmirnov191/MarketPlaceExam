using System.ComponentModel.DataAnnotations;

namespace MarketPlaceExam.Data.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"CartId{CartId}, ProductId: {ProductId}, Quantity: {Quantity} ";
        }
    }
}