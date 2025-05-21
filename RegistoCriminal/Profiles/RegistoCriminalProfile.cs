using AutoMapper;
using RegistoCriminal.Dtos.Cidadaos;
using RegistoCriminal.Dtos.RegistoCriminal;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class RegistoCriminalProfile : Profile
    {
        public RegistoCriminalProfile()
        {
            CreateMap<RegistosCriminal, RegistoCriminalDto>().ReverseMap();
            CreateMap<RegistosCriminal, BaseRegistoCriminalDto>().ReverseMap();
            CreateMap<RegistosCriminal, RegistoCriminalCreationDto>().ReverseMap();
            CreateMap<RegistosCriminal, RegistoCriminaViewModel>().ReverseMap();
            CreateMap<RegistosCriminal, RegistoCriminalUpdateDto>().ReverseMap();
            CreateMap<RegistoCriminaViewModel, RegistoCriminalViewModelDto>().ReverseMap();
        }
    }
}
