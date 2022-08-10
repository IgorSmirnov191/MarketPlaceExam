using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.App.ViewModels.ShoppingCart
{
    public class ShoppingCartProductsViewModel
    {
        public List<ShoppingCartViewModel> Products { get; set; }

        public decimal TotalProductsCost => Products.Select(x => x.Total).Sum();
    }
}
