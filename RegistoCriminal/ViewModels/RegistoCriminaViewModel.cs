using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.ViewModels
{
    public class RegistoCriminaViewModel : IViewModel
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;   

        public string? NumeroProcesso { get; set; }

        public DateOnly? DataOcorrencia { get; set; }

        public string? TipoOcorrencia { get; set; }

        public string? Sentenca { get; set; }

        public DateTime? DataSentenca { get; set; }

        public bool? Cumprido { get; set; }

        public string? Observacoes { get; set; }

        public int IdCidado { get; set; }
    }
}
