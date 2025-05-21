using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.Dtos.Solicitacoes
{
    public class BaseSolicitacaoRegistoDto
    {
        public DateTime Datasolicitacao { get; set; }

        public string Finalidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public bool? Urgencia { get; set; }

        public string Formapagamento { get; set; } = null!;

        public bool? Pago { get; set; }
    }
}
