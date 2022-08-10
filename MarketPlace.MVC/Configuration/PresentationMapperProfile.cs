using AutoMapper;
using Marketplace.App.ViewModels.Components;
using Marketplace.App.ViewModels.Home;
using Marketplace.App.ViewModels.Products;
using Marketplace.App.ViewModels.ShoppingCart;
using MarketPlace.MVC.Models;
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
                .ForMember(dest => dest.Products, x => x.MapFrom(src => src.CartItems))
                .ForMember(dest => dest.TotalProductsCost, x => x.MapFrom(src => src.TotalPrice))
                .ReverseMap();
        }
    }
}