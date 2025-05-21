namespace RegistoCriminal.Dtos.Pagamentos
{
    public class PagamentoUpdateDto : BasePagamentoDto
    {
        public DateTime Datapagamento { get; set; } = DateTime.Now;
    }
}
