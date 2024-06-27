using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Sale.Application.Features.Orders.Commands.Create;
using Sale.Application.Features.Orders.Commands.Delete;
using Sale.Application.Features.Orders.Queries.GetByCustomerId;
using Sale.Application.Features.Orders.Queries.GetBySellerId;
using Sale.Application.Features.Orders.Queries.GetList;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Order, CreateOrderCommand>().ReverseMap();
        CreateMap<Order,CreatedOrderResponse>().ReverseMap();

        CreateMap<Order, DeleteOrderCommand>().ReverseMap();
        CreateMap<Order, DeletedOrderResponse>().ReverseMap();

        CreateMap<Order, GetOrderByCustomerIdResponse>().ReverseMap();
        CreateMap<Order, GetOrderBySellerIdResponse>().ReverseMap();

        CreateMap<Order, GetListOrderListItemDto>().ReverseMap();
        CreateMap<Paginate<Order>, GetListResponse<GetListOrderListItemDto>>().ReverseMap();


    }
}
