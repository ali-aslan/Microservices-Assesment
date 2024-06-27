using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Sale.Application.Features.Products.Commands.Create;
using Sale.Application.Features.Products.Queries.GetList;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Products.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();

        CreateMap<Product, GetListProductListItemDto>().ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();
    }
}
