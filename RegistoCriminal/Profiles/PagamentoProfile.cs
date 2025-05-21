using AutoMapper;
using RegistoCriminal.Dtos.Pagamentos;
using RegistoCriminal.Dtos.RegistoCriminal;
using RegistoCriminal.Entities;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<Pagamento, PagamentoDto>().ReverseMap();
            CreateMap<Pagamento, BasePagamentoDto>().ReverseMap();
            CreateMap<Pagamento, PagamentoCreationDto>().ReverseMap();
            CreateMap<Pagamento, PagamentoUpdateDto>().ReverseMap();
            CreateMap<Pagamento, PagamentoViewModel>().ReverseMap();
            CreateMap<PagamentoViewModel, PagamentoViewModelDto>().ReverseMap();
        }
    }
}
