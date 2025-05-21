using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.ViewModels
{
    public class CidadoViewModel : IViewModel
    {
        public int Id { get; set; }
        
        public string NomeCompleto { get; set; } = null!;

        public string NumBi { get; set; } = null!;

        public string? Endereco { get; set; }

        public string? Provincia { get; set; }

        public string? Distrito { get; set; }

        public DateOnly Datanascimento { get; set; }

        public string? IdUtilizador { get; set; }
    }
}
