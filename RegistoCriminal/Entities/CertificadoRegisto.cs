using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegistoCriminal.Entities;

[Table("CertificadoRegisto")]
public partial class CertificadoRegisto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dataEmissao", TypeName = "datetime")]
    public DateTime? DataEmissao { get; set; }

    [Column("dataValidade", TypeName = "datetime")]
    public DateTime? DataValidade { get; set; }

    [Column("numeroReferencia")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NumeroReferencia { get; set; }

    [Column("conteudo")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Conteudo { get; set; }

    [Column("estadoCertificado")]
    [StringLength(150)]
    [Unicode(false)]
    public string? EstadoCertificado { get; set; }

    [Column("idFuncionarioEmissor")]
    public int IdFuncionarioEmissor { get; set; }

    [Column("idSolicitacao")]
    public int IdSolicitacao { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }

    [ForeignKey("IdFuncionarioEmissor")]
    [InverseProperty("CertificadoRegistos")]
    public virtual FuncionarioJudicial IdFuncionarioEmissorNavigation { get; set; } = null!;

    [ForeignKey("IdSolicitacao")]
    [InverseProperty("CertificadoRegistos")]
    public virtual Solicitacaoregisto IdSolicitacaoNavigation { get; set; } = null!;
}
