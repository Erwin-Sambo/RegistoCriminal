using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistoCriminal.Migrations
{
    /// <inheritdoc />
    public partial class AddldentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Utilizador",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nomecompleto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //        senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        tipoutilizador = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        nivelpermissao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        datacriacao = table.Column<DateTime>(type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Utilizador", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Cidadao",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        numBi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        endereco = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        provincia = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
            //        distrito = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
            //        datanascimento = table.Column<DateOnly>(type: "date", nullable: false),
            //        idUtilizador = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cidadao", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Cidadao_Utilizador_idUtilizador",
            //            column: x => x.idUtilizador,
            //            principalTable: "Utilizador",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FuncionarioJudicial",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cargo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        departamento = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        nivelacesso = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        idUtilizador = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FuncionarioJudicial", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_FuncionarioJudicial_Utilizador_idUtilizador",
            //            column: x => x.idUtilizador,
            //            principalTable: "Utilizador",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "logs",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IDUSER = table.Column<int>(type: "int", nullable: false),
            //        ACAO = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        DETALHES = table.Column<string>(type: "varchar(600)", unicode: false, maxLength: 600, nullable: true),
            //        ipaddress = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_logs", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_logs_Utilizador_IDUSER",
            //            column: x => x.IDUSER,
            //            principalTable: "Utilizador",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RegistosCriminal",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        numeroProcesso = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        dataOcorrencia = table.Column<DateOnly>(type: "date", nullable: true),
            //        tipoOcorrencia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sentenca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        dataSentenca = table.Column<DateTime>(type: "datetime", nullable: true),
            //        cumprido = table.Column<bool>(type: "bit", nullable: true),
            //        observacoes = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
            //        idCidado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RegistosCriminal", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_RegistosCriminal_Cidadao_idCidado",
            //            column: x => x.idCidado,
            //            principalTable: "Cidadao",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Solicitacaoregisto",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        datasolicitacao = table.Column<DateTime>(type: "datetime", nullable: false),
            //        finalidade = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        urgencia = table.Column<bool>(type: "bit", nullable: true),
            //        formapagamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        pago = table.Column<bool>(type: "bit", nullable: true),
            //        idCidado = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Solicitacaoregisto", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Solicitacaoregisto_Cidadao_idCidado",
            //            column: x => x.idCidado,
            //            principalTable: "Cidadao",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CertificadoRegisto",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        dataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
            //        dataValidade = table.Column<DateTime>(type: "datetime", nullable: true),
            //        numeroReferencia = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
            //        conteudo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        estadoCertificado = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        idFuncionarioEmissor = table.Column<int>(type: "int", nullable: false),
            //        idSolicitacao = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CertificadoRegisto", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_CertificadoRegisto_FuncionarioJudicial_idFuncionarioEmissor",
            //            column: x => x.idFuncionarioEmissor,
            //            principalTable: "FuncionarioJudicial",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CertificadoRegisto_Solicitacaoregisto_idSolicitacao",
            //            column: x => x.idSolicitacao,
            //            principalTable: "Solicitacaoregisto",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "pagamento",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        valor = table.Column<decimal>(type: "decimal(17,2)", nullable: true),
            //        metodo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        referencia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        datapagamento = table.Column<DateTime>(type: "datetime", nullable: false),
            //        idSolicitacao = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_pagamento", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_pagamento_Solicitacaoregisto_idSolicitacao",
            //            column: x => x.idSolicitacao,
            //            principalTable: "Solicitacaoregisto",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CertificadoRegisto_idFuncionarioEmissor",
            //    table: "CertificadoRegisto",
            //    column: "idFuncionarioEmissor");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CertificadoRegisto_idSolicitacao",
            //    table: "CertificadoRegisto",
            //    column: "idSolicitacao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cidadao_idUtilizador",
            //    table: "Cidadao",
            //    column: "idUtilizador");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FuncionarioJudicial_idUtilizador",
            //    table: "FuncionarioJudicial",
            //    column: "idUtilizador");

            //migrationBuilder.CreateIndex(
            //    name: "IX_logs_IDUSER",
            //    table: "logs",
            //    column: "IDUSER");

            //migrationBuilder.CreateIndex(
            //    name: "IX_pagamento_idSolicitacao",
            //    table: "pagamento",
            //    column: "idSolicitacao");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RegistosCriminal_idCidado",
            //    table: "RegistosCriminal",
            //    column: "idCidado");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Solicitacaoregisto_idCidado",
            //    table: "Solicitacaoregisto",
            //    column: "idCidado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "CertificadoRegisto");

            //migrationBuilder.DropTable(
            //    name: "logs");

            //migrationBuilder.DropTable(
            //    name: "pagamento");

            //migrationBuilder.DropTable(
            //    name: "RegistosCriminal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "FuncionarioJudicial");

            //migrationBuilder.DropTable(
            //    name: "Solicitacaoregisto");

            //migrationBuilder.DropTable(
            //    name: "Cidadao");

            //migrationBuilder.DropTable(
            //    name: "Utilizador");
        }
    }
}
