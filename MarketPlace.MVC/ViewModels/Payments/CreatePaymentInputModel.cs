using System.ComponentModel.DataAnnotations;

namespace MarketPlace.MVC.ViewModels.Payments
{
    public class CreatePaymentInputModel
    {
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

        [Required]
        [MaxLength(50)]
        public string? PayEmail { get; set; }

        [MaxLength(50)]
        public string? PayType { get; set; }

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
        public decimal Total { get; set; }

        public string? UserId { get; set; }
    }
}
