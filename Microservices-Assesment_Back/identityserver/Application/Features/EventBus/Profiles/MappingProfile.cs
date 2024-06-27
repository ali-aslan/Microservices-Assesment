using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventBus.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<SellerResponse, User>().ReverseMap();
    }
}
