using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Dealer.Application.Features.Suppliers.Commands.Create;
using Dealer.Application.Features.Suppliers.Queries.GetById;
using Dealer.Application.Features.Suppliers.Queries.GetByList;
using Dealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Profiles
{
    internal class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Supplier, CreateSupplierCommand>().ReverseMap();
            CreateMap<Supplier, CreatedSupplierResponse>().ReverseMap();


            CreateMap<Supplier, GetListSupplierListItemDto>().ReverseMap();
            CreateMap<Supplier, GetByIdSupplierResponse>().ReverseMap();
            CreateMap<Paginate<Supplier>, GetListResponse<GetListSupplierListItemDto>>().ReverseMap();

        }

    }
}
