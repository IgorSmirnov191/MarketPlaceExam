using MarketPlace.MVC.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.MVC.ViewModels.Products
{
    public class CreateProductInputModel
    {
        [Required]
        [StringLength(GlobalConstants.ProductNameMaxLenght, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = GlobalConstants.ProductNameMinLenght)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), GlobalConstants.PriceMinValue, GlobalConstants.PriceMaxValue, ErrorMessage = "Price must be positive number")]
        public decimal Price { get; set; }

        [Required]
        [Range(GlobalConstants.MinQuantityValue, int.MaxValue, ErrorMessage = "Quantity must be positive number more than zero")]
        public int Quantity { get; set; }

        public string Color { get; set; } = "Yellow";

        [Required]
        [StringLength(GlobalConstants.ProductDescriptionMaxLenght, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = GlobalConstants.ProductDescriptionMinLenght)]
        public string Description { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        public IFormFile Picture { get; set; }
    }
}
