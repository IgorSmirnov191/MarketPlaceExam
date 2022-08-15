using AutoMapper;
using Marketplace.MVC.ViewModels.Payments;
using MarketPlace.MVC.Models;
using MarketPlace.MVC.ViewModels.Categories;
using MarketPlace.MVC.ViewModels.Components;
using MarketPlace.MVC.ViewModels.Home;
using MarketPlace.MVC.ViewModels.Orders;
using MarketPlace.MVC.ViewModels.Payments;
using MarketPlace.MVC.ViewModels.Products;
using MarketPlace.MVC.ViewModels.ShoppingCart;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlace.MVC.Configuration
{
    public class PresentationMapperProfile : Profile
    {
        public PresentationMapperProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<Category, EditCategoryInputModel>().ReverseMap();
            CreateMap<Category, ProductCategoryViewModel>().ReverseMap();
            CreateMap<Category, HomeCategoryViewModel>().ReverseMap();
            CreateMap<Category, IndexCategoryViewModel>()
                .ForMember(icvm => icvm.CategoryId, x => x.MapFrom(c => c.Id));
            CreateMap<Category, SideBarCategoryViewModel>()
                .ForMember(sbcvm => sbcvm.Id, x => x.MapFrom(c => c.Id));

            CreateMap<CartItemModel, ShoppingCartViewModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, x => x.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PictureUrl, x => x.MapFrom(src => src.Product.Picture.Uri))
                .ForMember(dest => dest.Price, x => x.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Total, x => x.MapFrom(src => src.Quantity * src.Product.Price))
                .ReverseMap();

            CreateMap<CartModel, CartViewModel>()
                .ForMember(dest=>dest.Id, x=> x.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, x => x.MapFrom(src => src.CartItems))
                .ForMember(dest => dest.TotalProductsCost, x => x.MapFrom(src => src.TotalPrice))
                .ReverseMap();

            CreateMap<StockModel, DetailsProductViewModel>()
               .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
               .ForMember(dest => dest.ProductName, x => x.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.Price, x=> x.MapFrom(src => src.Product.Price))
               .ForMember(dest => dest.Description, x => x.MapFrom(src => src.Product.Description))
               .ForMember(dest => dest.AvailableQuantity, x => x.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.CategoryName, x => x.MapFrom(src => src.Product.Category.Name))
               .ForMember(dest => dest.Picture, x => x.MapFrom(src => src.Product.Picture.Uri))
               .ReverseMap();

            CreateMap < StockModel, EditProductInputModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(src => src.ProductId))
               .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.Price, x => x.MapFrom(src => src.Product.Price))
               .ForMember(dest => dest.Description, x => x.MapFrom(src => src.Product.Description))
               .ForMember(dest => dest.Quantity, x => x.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.CategoryName, x => x.MapFrom(src => src.Product.Category.Name))
               .ReverseMap();

            CreateMap<ProductModel, AllProductViewModel>()
               .ForMember(dest => dest.Id, x => x.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Name))
              .ForMember(dest => dest.Price, x => x.MapFrom(src => src.Price))
              .ForMember(dest => dest.Picture, x => x.MapFrom(src => src.Picture.Uri))
              .ReverseMap();
            
            CreateMap<Product, AllProductViewModel>()
               .ForMember(apvm => apvm.Picture, x => x.MapFrom(p => p.Picture.Uri)).ReverseMap(); ;

            CreateMap<Product, HomeProductViewModel>()
                .ForMember(hpvm => hpvm.PictureUrl, x => x.MapFrom(p => p.Picture.Uri)).ReverseMap(); ;

            CreateMap<Product, EditProductInputModel>().ReverseMap();

            CreateMap<Product, CategoriesProductViewModel>()
                .ForMember(cpvm => cpvm.Picture, x => x.MapFrom(p => p.Picture.Uri));

            CreateMap<Product, HomeSearchViewModel>()
                .ForMember(hsvm => hsvm.Picture, x => x.MapFrom(p => p.Picture.Uri));

            CreateMap<Payment, MyPaymentsViewModel>().ReverseMap();
            CreateMap<PaymentModel, CreatePaymentInputModel>()
                 .ForMember(dest => dest.PayName, x => x.MapFrom(src => src.PayUserName))
                 .ForMember(dest => dest.PayPhone, s=> s.MapFrom(src => src.PayPhoneNumber))
                 .ForMember(dest => dest.ShipPhone, s => s.MapFrom(src => src.ShipPhoneNumber))
                 .ForMember(dest => dest.PayAddress, s => s.MapFrom(src => src.PayAddress))
                 .ReverseMap();

        }
    }
}