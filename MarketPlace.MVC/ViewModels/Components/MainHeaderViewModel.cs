using MarketPlaceExam.Business.Model;

namespace MarketPlace.MVC.ViewModels.Components
{
    public class MainHeaderViewModel
    {
        public IEnumerable<CategoryModel> ListCategories { get; set; } = new List<CategoryModel>();

        public CartModel CartModel { get; set; } = new CartModel();
    }
}
