using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.ViewModels
{
    public class FuncionarioJudicialViewModel : IViewModel
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; } = null!;
        public string? Cargo { get; set; }

        public string Departamento { get; set; } = null!;

        public string Nivelacesso { get; set; } = null!;

        public string IdUtilizador { get; set; } = null!;
    }
}
