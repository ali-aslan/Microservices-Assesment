using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Dealer.Application.Features.Shippers.Commands.Create;
using Dealer.Application.Features.Shippers.Queries.GetById;
using Dealer.Application.Features.Shippers.Queries.GetByList;

using Dealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Shippers.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
     
        CreateMap<Shipper, CreateShipperCommand>().ReverseMap();
        CreateMap<Shipper, CreatedShipperResponse>().ReverseMap();


        CreateMap<Shipper, GetListShipperListItemDto>().ReverseMap();
        CreateMap<Shipper, GetByIdShipperResponse>().ReverseMap();
        CreateMap<Paginate<Shipper>, GetListResponse<GetListShipperListItemDto>>().ReverseMap();
    }
}
