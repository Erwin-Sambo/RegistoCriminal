using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Entities;

namespace RegistoCriminal.Data;

public partial class RegistoCriminalContext : DbContext
{
    public RegistoCriminalContext()
    {
    }

    public RegistoCriminalContext(DbContextOptions<RegistoCriminalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<CertificadoRegisto> CertificadoRegistos { get; set; }

    public virtual DbSet<Cidadao> Cidadaos { get; set; }

    public virtual DbSet<FuncionarioJudicial> FuncionarioJudicials { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<RegistosCriminal> RegistosCriminals { get; set; }

    public virtual DbSet<Solicitacaoregisto> Solicitacaoregistos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HGKCR8J;Initial Catalog=RegistoCriminal;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<CertificadoRegisto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3213E83F5E822AA9");

            entity.HasOne(d => d.IdFuncionarioEmissorNavigation).WithMany(p => p.CertificadoRegistos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__idFun__236943A5");

            entity.HasOne(d => d.IdSolicitacaoNavigation).WithMany(p => p.CertificadoRegistos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__idSol__245D67DE");
        });

        modelBuilder.Entity<Cidadao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cidadao__3213E83F7C3C30EE");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.Cidadaos).HasConstraintName("FK__Cidadao__idUtili__17036CC0");
        });

        modelBuilder.Entity<FuncionarioJudicial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funciona__3213E83FECB2DE74");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.FuncionarioJudicials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__idUti__14270015");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__logs__3214EC272ABE76E2");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__logs__IDUSER__114A936A");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pagament__3213E83F32BFC9AE");

            entity.HasOne(d => d.IdSolicitacaoNavigation).WithMany(p => p.Pagamentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pagamento__idSol__2739D489");
        });

        modelBuilder.Entity<RegistosCriminal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registos__3213E83FA0006D4C");

            entity.Property(e => e.Cumprido).HasDefaultValue(false);

            entity.HasOne(d => d.IdCidadoNavigation).WithMany(p => p.RegistosCriminals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistosC__idCid__1AD3FDA4");
        });

        modelBuilder.Entity<Solicitacaoregisto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicita__3213E83F4B4E5BC2");

            entity.Property(e => e.Datasolicitacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Pago).HasDefaultValue(false);
            entity.Property(e => e.Urgencia).HasDefaultValue(false);

            entity.HasOne(d => d.IdCidadoNavigation).WithMany(p => p.Solicitacaoregistos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitac__idCid__208CD6FA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
