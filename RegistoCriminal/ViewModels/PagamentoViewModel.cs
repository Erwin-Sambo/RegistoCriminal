namespace RegistoCriminal.ViewModels
{
    public class PagamentoViewModel : IViewModel
    {
        public int Id { get; set; }
        public decimal? Valor { get; set; }
        public string? Metodo { get; set; }
        public string? Referencia { get; set; }
        public int IdSolicitacao { get; set; }

    }
}
