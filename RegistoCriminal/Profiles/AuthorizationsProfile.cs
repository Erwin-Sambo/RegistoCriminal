using AutoMapper;
using RegistoCriminal.Entities;

namespace RegistoCriminal.Profiles
{
    public class AuthorizationsProfile : Profile
    {
        public AuthorizationsProfile()
        {
            CreateMap<AspSystemClaims, AspSystemClaimsDto>().ReverseMap();
        }
    }
}
