using AutoMapper;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.ViewModels;
using FlowerShop.DAL.Entities;


namespace FlowerShop.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryVm>();

            CreateMap<CategoryModel, Category>();

            CreateMap<CustomBouquet, CustomBouquetVm>();

            CreateMap<CustomBouquetModel, CustomBouquet>();

            CreateMap<Item, ItemListVm>();

            CreateMap<Item, ItemVm>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ItemModel, Item>();

            CreateMap<Order, OrderVm>()
                .ForMember(dest => dest.OrderStatusName, opt => opt.MapFrom(src => src.OrderStatus.Name));

            CreateMap<OrderModel, Order>();

            CreateMap<WishlistModel, Wishlist>();
        }
    }
}
