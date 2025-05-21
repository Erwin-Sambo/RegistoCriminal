using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.ViewModels
{
    public class SolicitacaoregistoViewModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime Datasolicitacao { get; set; }

        public string Finalidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public bool? Urgencia { get; set; }

        public string Formapagamento { get; set; } = null!;

        public bool? Pago { get; set; }
    }
}
