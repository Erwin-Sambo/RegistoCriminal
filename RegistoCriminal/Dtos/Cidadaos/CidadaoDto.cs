namespace RegistoCriminal.Dtos.Cidadaos
{
    public class CidadaoDto : BaseCidadoDto
    {

        public int Id { get; set; }
        public string? IdUtilizador { get; set; }
        public string NomeCompleto { get; set; } = null!;
    }
}
