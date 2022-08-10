using MarketPlaceExam.Business.Model;

namespace Marketplace.App.ViewModels.Components
{
    public class MainHeaderViewModel
    {
        public IEnumerable<CategoryModel> ListCategories { get; set; } = new List<CategoryModel>();

        public int ShoppingCartProductCount { get; set; }

        public decimal ShoppingCartTotalPrice { get; set; }
    }
}
