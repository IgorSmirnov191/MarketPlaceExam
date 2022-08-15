using System.ComponentModel.DataAnnotations;

namespace MarketPlace.MVC.ViewModels.Products
{
    public class AddPictureProductInputModel
    {
        public int Id { get; set; }

        [Required]
        public IFormFile Picture { get; set; }
    }
}
