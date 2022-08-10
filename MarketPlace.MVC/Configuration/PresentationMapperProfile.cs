using AutoMapper;
using Marketplace.App.ViewModels.Components;
using Marketplace.App.ViewModels.Home;
using Marketplace.App.ViewModels.Products;
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
        }
    }
}
