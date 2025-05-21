using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("FuncionarioJudicial")]
public partial class FuncionarioJudicial
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cargo")]
    [StringLength(150)]
    [Unicode(false)]
    public string? Cargo { get; set; }

    [Column("departamento")]
    [StringLength(150)]
    [Unicode(false)]
    public string Departamento { get; set; } = null!;

    [Column("nivelacesso")]
    [StringLength(150)]
    [Unicode(false)]
    public string Nivelacesso { get; set; } = null!;

    [Column("idUtilizador")]
    [StringLength(450)]
    public string IdUtilizador { get; set; } = null!;

    //[Timestamp]
    //public byte[]? RowVersion { get; set; }

    [InverseProperty("IdFuncionarioEmissorNavigation")]
    public virtual ICollection<CertificadoRegisto> CertificadoRegistos { get; set; } = new List<CertificadoRegisto>();

    [ForeignKey("IdUtilizador")]
    [InverseProperty("FuncionarioJudicials")]
    public virtual AspNetUser IdUtilizadorNavigation { get; set; } = null!;
}
