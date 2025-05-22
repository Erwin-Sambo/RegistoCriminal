using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("Cidadao")]
public partial class Cidadao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("numBi")]
    [StringLength(20)]
    [Unicode(false)]
    public string NumBi { get; set; } = null!;

    [Column("nomecompleto")]
    [StringLength(150)]
    [Unicode(false)]
    public string NomeCompleto { get; set; } = null!;

    [Column("endereco")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Endereco { get; set; }

    [Column("provincia")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Provincia { get; set; }

    [Column("distrito")]
    [StringLength(60)]
    [Unicode(false)]
    public string? Distrito { get; set; }

    [Column("datanascimento")]
    public DateOnly Datanascimento { get; set; }

    [Column("idUtilizador")]
    [StringLength(450)]
    public string? IdUtilizador { get; set; }

    //[Timestamp]
    //public byte[]? RowVersion { get; set; }

    [ForeignKey("IdUtilizador")]
    [InverseProperty("Cidadaos")]
    public virtual AspNetUser? IdUtilizadorNavigation { get; set; }

    [InverseProperty("IdCidadoNavigation")]
    public virtual ICollection<RegistosCriminal> RegistosCriminals { get; set; } = new List<RegistosCriminal>();

    [InverseProperty("IdCidadoNavigation")]
    public virtual ICollection<Solicitacaoregisto> Solicitacaoregistos { get; set; } = new List<Solicitacaoregisto>();
}
