using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Model
{
    public class CartModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public IList<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();

        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(x => x.Quantity * x.Product.Price);
            }
        }

        public int TotalAmountOfItemsInCart
        {
            get
            {
                return CartItems.Sum(x => x.Quantity);
            }
        }
    }
}