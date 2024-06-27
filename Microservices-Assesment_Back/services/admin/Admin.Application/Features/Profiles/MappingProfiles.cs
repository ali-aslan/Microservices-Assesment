using Admin.Application.Features.EventBus;
using Admin.Domain.DTOs;
using AutoMapper;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.Features.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {

            CreateMap<SupplierResponse,Supplier>().ReverseMap();

            CreateMap<ShipperResponse, Shipper>().ReverseMap();

            CreateMap<SellerResponse, Seller>().ReverseMap();

            CreateMap<Customer,CustomerResponse>().ReverseMap();

            CreateMap<Product,ProductResponse>().ReverseMap();

            CreateMap<GetOrderResponse,OrderResponse>().ReverseMap();


        }
    }
}
