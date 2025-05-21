using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistoCriminal.Dtos.Pagamentos
{
    public class BasePagamentoDto
    {
        public decimal? Valor { get; set; }

        public string? Metodo { get; set; }

        public string? Referencia { get; set; }

        //public string? Estado { get; set; }
    }
}
