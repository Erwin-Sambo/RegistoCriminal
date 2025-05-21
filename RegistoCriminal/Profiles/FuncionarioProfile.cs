using AutoMapper;
using RegistoCriminal.Dtos.Cidadaos;
using RegistoCriminal.Dtos.Funcionarios;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioJudicial, FuncionarioDto>().ReverseMap();
            CreateMap<FuncionarioJudicial, BaseFuncionarioDto>().ReverseMap();
            CreateMap<FuncionarioJudicial, FuncionarioCreationDto>().ReverseMap();
            CreateMap<FuncionarioJudicial, FuncionarioJudicialViewModel>().ReverseMap();
            CreateMap<FuncionarioJudicial, FuncionarioUpdateDto>().ReverseMap();
            CreateMap<FuncionarioJudicialViewModelDto, FuncionarioJudicialViewModel>().ReverseMap();
        }
    }
}
