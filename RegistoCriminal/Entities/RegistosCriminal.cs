using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("RegistosCriminal")]
public partial class RegistosCriminal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("numeroProcesso")]
    [StringLength(20)]
    [Unicode(false)]
    public string? NumeroProcesso { get; set; }

    [Column("dataOcorrencia")]
    public DateOnly? DataOcorrencia { get; set; }

    [Column("tipoOcorrencia")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TipoOcorrencia { get; set; }

    [Column("sentenca")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Sentenca { get; set; }

    [Column("dataSentenca", TypeName = "datetime")]
    public DateTime? DataSentenca { get; set; }

    [Column("cumprido")]
    public bool? Cumprido { get; set; }

    [Column("observacoes")]
    [StringLength(300)]
    [Unicode(false)]
    public string? Observacoes { get; set; }

    [Column("idCidado")]
    public int IdCidado { get; set; }

    //[Timestamp]
    //public byte[]? RowVersion { get; set; }

    [ForeignKey("IdCidado")]
    [InverseProperty("RegistosCriminals")]
    public virtual Cidadao IdCidadoNavigation { get; set; } = null!;
}
