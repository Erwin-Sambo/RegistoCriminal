using AutoMapper;
using RegistoCriminal.Dtos.Certificado;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class CertificadosProfile : Profile
    {
        public CertificadosProfile()
        {
            CreateMap<CertificadoRegisto, CertidicadoRegistoDto>().ReverseMap();
            CreateMap<CertificadoRegisto, BaseCertidicadoRegistoDto>().ReverseMap();
            CreateMap<CertificadoRegisto, CertidicadoRegistoCreationDto>().ReverseMap();
            CreateMap<CertificadoRegisto, CertidicadoRegistoUpdateDto>().ReverseMap();
            CreateMap<CertificadoRegisto, CertidicadoRegistoViewModel>().ReverseMap();
            //CreateMap<CertificadoRegisto, CertidicadoRegistoViewModelDto>().ReverseMap();
            CreateMap<CertidicadoRegistoViewModel, CertidicadoRegistoViewModelDto>().ReverseMap();
        }
    }
}
