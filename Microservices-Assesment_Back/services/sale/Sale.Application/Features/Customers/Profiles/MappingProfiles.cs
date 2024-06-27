using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Sale.Application.Features.Customers.Commands.Create;
using Sale.Application.Features.Customers.Commands.Delete;
using Sale.Application.Features.Customers.Queries.GetById;
using Sale.Application.Features.Customers.Queries.GetList;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();

            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();


            CreateMap<Customer, GetListCustomerListItemDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerResponse>().ReverseMap();
            CreateMap<Paginate<Customer>, GetListResponse<GetListCustomerListItemDto>>().ReverseMap();



        }
    }
}
