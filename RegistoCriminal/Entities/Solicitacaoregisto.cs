using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("Solicitacaoregisto")]
public partial class Solicitacaoregisto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("datasolicitacao", TypeName = "datetime")]
    public DateTime Datasolicitacao { get; set; }

    [Column("finalidade")]
    [StringLength(255)]
    [Unicode(false)]
    public string Finalidade { get; set; } = null!;

    [Column("estado")]
    [StringLength(20)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column("urgencia")]
    public bool? Urgencia { get; set; }

    [Column("formapagamento")]
    [StringLength(50)]
    [Unicode(false)]
    public string Formapagamento { get; set; } = null!;

    [Column("pago")]
    public bool? Pago { get; set; }

    [Column("idCidado")]
    public int IdCidado { get; set; }

    //[Timestamp]
    //public byte[]? RowVersion { get; set; }

    [InverseProperty("IdSolicitacaoNavigation")]
    public virtual ICollection<CertificadoRegisto> CertificadoRegistos { get; set; } = new List<CertificadoRegisto>();

    [ForeignKey("IdCidado")]
    [InverseProperty("Solicitacaoregistos")]
    public virtual Cidadao IdCidadoNavigation { get; set; } = null!;

    [InverseProperty("IdSolicitacaoNavigation")]
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
