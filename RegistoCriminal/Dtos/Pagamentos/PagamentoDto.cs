namespace RegistoCriminal.Dtos.Pagamentos
{
    public class PagamentoDto : BasePagamentoDto
    {
        public int Id { get; set; }

        public int IdSolicitacao { get; set; }
        public DateTime Datapagamento { get; set; }
    }
}
