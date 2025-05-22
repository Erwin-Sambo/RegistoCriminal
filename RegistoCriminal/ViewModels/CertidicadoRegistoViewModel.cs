using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.ViewModels
{
    public class CertidicadoRegistoViewModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime? DataEmissao { get; set; }

        public DateTime? DataValidade { get; set; }

        public string? NumeroReferencia { get; set; }

        public string? Conteudo { get; set; }

        public string? EstadoCertificado { get; set; }

        public string FuncionarioEmissor { get; set; } = string.Empty;

    }
}
