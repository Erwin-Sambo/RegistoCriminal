using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.Dtos.Funcionarios
{
    public class BaseFuncionarioDto
    {
        public string? Cargo { get; set; }

        public string Departamento { get; set; } = string.Empty;

        public string Nivelacesso { get; set; } = string.Empty;

    }
}
