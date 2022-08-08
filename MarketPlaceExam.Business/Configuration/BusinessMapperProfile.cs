using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Configuration
{
    public class BusinessMapperProfile: Profile
    {
        public BusinessMapperProfile()
        { 
            CreateMap<CartItemModel, CartItem>().ReverseMap();
            CreateMap<CartModel, Cart>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<PaymentModel, Payment>().ReverseMap();
            CreateMap<PictureModel, Picture>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<ShipmentModel, Shipment>().ReverseMap();
            CreateMap<ShipperModel, Shipper>().ReverseMap();
            CreateMap<StockModel, Stock>().ReverseMap();
            CreateMap<SupplierModel, Supplier>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();


        }
    }
}
