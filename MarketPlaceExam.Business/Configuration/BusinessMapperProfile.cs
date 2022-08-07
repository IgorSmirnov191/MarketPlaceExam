using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Configuration
{
    public class BusinessMapperProfile: Profile
    {
        public BusinessMapperProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();

            CreateMap<CartItemModel, CartItem>().ReverseMap();
        }
    }
}
