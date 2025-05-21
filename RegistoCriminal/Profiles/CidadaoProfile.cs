using AutoMapper;
using RegistoCriminal.Dtos.Cidadaos;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class CidadaoProfile : Profile
    {
        public CidadaoProfile()
        {
            CreateMap<Cidadao, CidadaoDto>().ReverseMap();
            CreateMap<Cidadao, BaseCidadoDto>().ReverseMap();
            CreateMap<Cidadao, CidadaoCreationDto>().ReverseMap();
            CreateMap<CidadoViewModel, Cidadao>().ReverseMap();
            CreateMap<UpdateCidadoDto, Cidadao>().ReverseMap();
            CreateMap<CidadoViewModel, CidadoViewModelDto>().ReverseMap();
            
        }
    }
}
