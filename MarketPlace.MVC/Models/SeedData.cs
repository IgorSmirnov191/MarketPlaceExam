using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //categories
            var categories = serviceProvider.GetRequiredService<ICategoryService>();
            if (categories.IsCategoriesEmpty())
            {
                CategoryModel categorymodel;
                //Default Category -- Sport foods
                categorymodel = new CategoryModel
                {
                    Name = "Sports foods",
                    Description = "Specialised products used to provide a convenient source of nutrients when it is impractical to consume everyday foods"

                };
                categories.AddCategory(categorymodel);

                //Default Category -- Medical supplements
                categorymodel = new CategoryModel
                {
                    Name = "Medical supplements",
                    Description = "Supplements used to prevent or treat clinical issues including diagnosed nutrient deficiencies. Should be used within a larger plan under the expert guidance of a Medical Practitioner/Accredited Sports Dietitian."

                };
                categories.AddCategory(categorymodel);

                //Default Category -- Performance supplements
                categorymodel = new CategoryModel
                {
                    Name = "Performance supplements",
                    Description = "Supplements/ingredients that can support or enhance sports performance. Best used with an individualised and event-specific protocol, with the expert guidance of an Accredited Sports Dietitian."

                };
                categories.AddCategory(categorymodel);


            }

            // users
            var users = serviceProvider.GetRequiredService<IUserService>();
            if (users.IsUsersEmpty())
            {
                UserModel usermodel;
                //Default user -- guest
                usermodel = new UserModel
                {
                    Name = "guest"
                };
                users.AddUser(usermodel);
                //Default user -- admin
                usermodel = new UserModel
                {
                    Name = "admin"
                };
                users.AddUser(usermodel);
            }

            // carts
            var carts = serviceProvider.GetRequiredService<ICartService>();
            if (carts.IsCartsEmpty())
            {
                //Defaul usercart -- Guest's cart
                CartModel cartmodel = new CartModel
                {
                    UserId = 1,
                    Description = "Guest's Cart",
                    AuthToken = ""
                };
            }

            // suppliers
            var suppliers = serviceProvider.GetRequiredService<ISupplierService>();
            if(suppliers.IsSuppliersEmpty())
            {
                SupplierModel suppliermodel = new SupplierModel
                {
                    Name = "UNITED SOFT DRINKS B.V.",
                    Description = "",
                    Address = "Reactorweg 69",
                    City = "Utrecht",
                    ZipCode = "3542 AD",
                    Phone = "030 - 2410590",
                    URL = "https:///aa-drink.com"
                };
                suppliers.AddSupplier(suppliermodel);
 
            }

            // pictures
            var pictures = serviceProvider.GetRequiredService<IPictureService>();
            if(pictures.IsPicturesEmpty())
            {
                PictureModel picturemodel = new PictureModel
                {
                    Uri = "https:///aa-drink.com/uploads/drinks/2021-07-02-02-37-4024760210.png"
                };
                pictures.AddPicture(picturemodel);
            }

            // products
            var products = serviceProvider.GetRequiredService<IProductService>();
            if(products.IsProductsEmpty())
            {
                ProductModel productmodel = new ProductModel
                {
                    Name = "AA Drink Iso Lemon",
                    Description = "AA Drink Hydration Pet 12 x 0.5 liter",
                    Price = 12.52m,
                    StockKeepUnitId = "AAIsoLemon12x500",
                    QuantityPerUnit = 12,
                    CategoryId = 1,
                    SuppplierId = 1,
                    PictureId = 1
                };
            }
            
            // stocks
            var stocks = serviceProvider.GetRequiredService<IStockService>();
            if (stocks.IsStocksEmpty())
            {
                StockModel stockmodel = new StockModel
                {
                    ProductId = 1,
                    Quantity = 100
                };
            }

        }
    }
}
