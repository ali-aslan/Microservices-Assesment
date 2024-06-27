using AutoMapper;
using Contracts.Responses;
using Dealer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.EventHandlers.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Shipper, ShipperResponse>().ReverseMap();
            CreateMap<Supplier, SupplierResponse>().ReverseMap();
        }
    }
}
