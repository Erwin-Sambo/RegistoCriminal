using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("logs")]
public partial class Log
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("IDUSER")]
    [StringLength(450)]
    public string Iduser { get; set; } = null!;

    [Column("ACAO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Acao { get; set; }

    [Column("DETALHES")]
    [StringLength(600)]
    [Unicode(false)]
    public string? Detalhes { get; set; }

    [Column("ipaddress")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Ipaddress { get; set; }

    [ForeignKey("Iduser")]
    [InverseProperty("Logs")]
    public virtual AspNetUser IduserNavigation { get; set; } = null!;
}
