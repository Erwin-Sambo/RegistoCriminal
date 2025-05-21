namespace RegistoCriminal.Parametros
{
    public class ParametrosPages
    {
        const int tamanhoMaximo = 100;
        public string? pesquisaQuery { get; set; }
        public int numeroPagina { get; set; } = 1;
        private int _tamanhoPagina { get; set; } = 10;
        public int TamanhoPagina
        {
            get => _tamanhoPagina;
            set =>
                _tamanhoPagina = (value > tamanhoMaximo) ? tamanhoMaximo : value;
        }
        public string? OrderBy { get; set; }
    }
}
