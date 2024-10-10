using AutoMapper;
using Identity.Domain.Entities;
using Core.Security.Entities;

namespace Identity.Application.Features.Auth.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
           CreateMap<RefreshToken<Guid,Guid>,RefreshToken>().ReverseMap();
    }

}
