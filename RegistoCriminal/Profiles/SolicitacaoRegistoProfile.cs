using AutoMapper;
using RegistoCriminal.Dtos.Pagamentos;
using RegistoCriminal.Dtos.Solicitacoes;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class SolicitacaoRegistoProfile : Profile
    {
        public SolicitacaoRegistoProfile()
        {
            CreateMap<Solicitacaoregisto, SolicitacaoRegistoDto>().ReverseMap();
            CreateMap<Solicitacaoregisto, BaseSolicitacaoRegistoDto>().ReverseMap();
            CreateMap<Solicitacaoregisto, SolicitacaoRegistoCreationDto>().ReverseMap();
            CreateMap<Solicitacaoregisto, SolicitacaoRegistoUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null));
            CreateMap<Solicitacaoregisto, SolicitacaoregistoViewModel>().ReverseMap();
            CreateMap<SolicitacaoregistoViewModel, SolicitacaoregistoViewModelDto>().ReverseMap();
        }
    }
}
