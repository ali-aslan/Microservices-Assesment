using AutoMapper;
using Contracts.Responses;
using Core.Persistence.Paging;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.EventHandlers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Paginate<OrderListResponse>, Paginate<Order>>().ReverseMap();

            //CreateMap<Order,OrderListResponse>().ReverseMap();

            //CreateMap<IList<Order>,IList<OrderListResponse>>().ReverseMap();


            CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new CustomerResponse
            {
                Id = src.CustomerID,
                Name = src.Customer.Name,
                Email = src.Customer.Email,
                Phone = src.Customer.Phone,

            }))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new ProductResponse
            {
                Id = src.ProductID,
                Name = src.Product.Name,
                CategoryName = src.Product.CategoryName,
                Price = src.Product.Price,
                StockQuantity = src.Product.StockQuantity,
            }))
            .ForMember(dest => dest.SupplierID, opt => opt.MapFrom(src => src.SupplierID))
            .ForMember(dest => dest.ShipperID, opt => opt.MapFrom(src => src.ShipperID))
            .ForMember(dest => dest.SellerID, opt => opt.MapFrom(src => src.SellerID))
            .ReverseMap();


        }

    }
}

