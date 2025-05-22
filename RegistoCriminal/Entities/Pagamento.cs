using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("pagamento")]
public partial class Pagamento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("valor", TypeName = "decimal(17, 2)")]
    public decimal? Valor { get; set; }

    [Column("metodo")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Metodo { get; set; }

    [Column("referencia")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Referencia { get; set; }

    [Column("estado")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column("datapagamento", TypeName = "datetime")]
    public DateTime Datapagamento { get; set; }

    [Column("idSolicitacao")]
    public int IdSolicitacao { get; set; }

    //[Timestamp]
    //public byte[]? RowVersion { get; set; }

    [ForeignKey("IdSolicitacao")]
    [InverseProperty("Pagamentos")]
    public virtual Solicitacaoregisto IdSolicitacaoNavigation { get; set; } = null!;
}
