using AutoMapper;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.InputModels;
using FlowerShop.BLL.Models.ViewModels;
using FlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryModel>()
                .ReverseMap();

            CreateMap<CustomBouquet, CustomBouquetModel>() 
                .ReverseMap();

            CreateMap<Item, ItemModel>();

            CreateMap<ItemModel, Item>();

            CreateMap<ItemOrder, ItemOrderModel>()
                .ReverseMap();

            CreateMap<Order, OrderModel>()
                .ForMember(om => om.OrderStatusName, o => o.MapFrom(x => x.OrderStatus.Name))
                .ReverseMap();

            CreateMap<Wishlist, WishlistModel>()
                .ReverseMap();

            CreateMap<CategoryModel, CategoryVm>();

            CreateMap<CustomBouquetModel, CustomBouquetVm>();
        }
    }
}
