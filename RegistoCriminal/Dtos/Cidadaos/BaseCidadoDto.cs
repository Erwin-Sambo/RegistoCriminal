namespace RegistoCriminal.Dtos.Cidadaos
{
    public class BaseCidadoDto
    {
        public string NumBi { get; set; } = null!;

        public string? Endereco { get; set; }

        public string? Provincia { get; set; }

        public string? Distrito { get; set; }

        public DateOnly Datanascimento { get; set; }
    }
}
