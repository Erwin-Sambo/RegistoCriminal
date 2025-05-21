using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.Dtos.RegistoCriminal
{
    public class BaseRegistoCriminalDto
    {
        public string? NumeroProcesso { get; set; }

        public DateOnly? DataOcorrencia { get; set; }

        public string? TipoOcorrencia { get; set; }

        public string? Sentenca { get; set; }

        public DateTime? DataSentenca { get; set; }

        public bool? Cumprido { get; set; }

        public string? Observacoes { get; set; }
    }
}
