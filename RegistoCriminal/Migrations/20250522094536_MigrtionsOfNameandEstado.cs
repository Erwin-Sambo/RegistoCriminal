using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistoCriminal.Migrations
{
    /// <inheritdoc />
    public partial class MigrtionsOfNameandEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CertificadoRegisto_FuncionarioJudicial_idFuncionarioEmissor",
            //    table: "CertificadoRegisto");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_CertificadoRegisto_Solicitacaoregisto_idSolicitacao",
            //    table: "CertificadoRegisto");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cidadao_Utilizador_idUtilizador",
            //    table: "Cidadao");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FuncionarioJudicial_Utilizador_idUtilizador",
            //    table: "FuncionarioJudicial");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_logs_Utilizador_IDUSER",
            //    table: "logs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_pagamento_Solicitacaoregisto_idSolicitacao",
            //    table: "pagamento");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_RegistosCriminal_Cidadao_idCidado",
            //    table: "RegistosCriminal");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Solicitacaoregisto_Cidadao_idCidado",
            //    table: "Solicitacaoregisto");

            //migrationBuilder.DropTable(
            //    name: "Utilizador");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Solicitacaoregisto",
            //    table: "Solicitacaoregisto");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RegistosCriminal",
            //    table: "RegistosCriminal");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_pagamento",
            //    table: "pagamento");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_logs",
            //    table: "logs");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_FuncionarioJudicial",
            //    table: "FuncionarioJudicial");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Cidadao",
            //    table: "Cidadao");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_CertificadoRegisto",
            //    table: "CertificadoRegisto");

            //migrationBuilder.DropIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "urgencia",
            //    table: "Solicitacaoregisto",
            //    type: "bit",
            //    nullable: true,
            //    defaultValue: false,
            //    oldClrType: typeof(bool),
            //    oldType: "bit",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<bool>(
            //    name: "pago",
            //    table: "Solicitacaoregisto",
            //    type: "bit",
            //    nullable: true,
            //    defaultValue: false,
            //    oldClrType: typeof(bool),
            //    oldType: "bit",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "datasolicitacao",
            //    table: "Solicitacaoregisto",
            //    type: "datetime",
            //    nullable: false,
            //    defaultValueSql: "(getdate())",
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime");

            //migrationBuilder.AlterColumn<bool>(
            //    name: "cumprido",
            //    table: "RegistosCriminal",
            //    type: "bit",
            //    nullable: true,
            //    defaultValue: false,
            //    oldClrType: typeof(bool),
            //    oldType: "bit",
            //    oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "pagamento",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

        //migrationBuilder.AlterColumn<string>(
        //    name: "IDUSER",
        //    table: "logs",
        //    type: "nvarchar(450)",
        //    maxLength: 450,
        //    nullable: false,
        //    oldClrType: typeof(int),
        //    oldType: "int");

        //migrationBuilder.AlterColumn<string>(
        //    name: "idUtilizador",
        //    table: "FuncionarioJudicial",
        //    type: "nvarchar(450)",
        //    maxLength: 450,
        //    nullable: false,
        //    oldClrType: typeof(int),
        //    oldType: "int");

        //migrationBuilder.AlterColumn<string>(
        //    name: "idUtilizador",
        //    table: "Cidadao",
        //    type: "nvarchar(450)",
        //    maxLength: 450,
        //    nullable: true,
        //    oldClrType: typeof(int),
        //oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "nomecompleto",
                table: "Cidadao",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__Solicita__3213E83F4B4E5BC2",
            //    table: "Solicitacaoregisto",
            //    column: "id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__Registos__3213E83FA0006D4C",
            //    table: "RegistosCriminal",
            //    column: "id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__pagament__3213E83F32BFC9AE",
            //    table: "pagamento",
            //    column: "id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__logs__3214EC272ABE76E2",
            //    table: "logs",
            //    column: "ID");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__Funciona__3213E83FECB2DE74",
            //    table: "FuncionarioJudicial",
            //    column: "id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__Cidadao__3213E83F7C3C30EE",
            //    table: "Cidadao",
            //    column: "id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK__Certific__3213E83F5E822AA9",
            //    table: "CertificadoRegisto",
            //    column: "id");

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleAspNetUser",
            //    columns: table => new
            //    {
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleAspNetUser", x => new { x.RoleId, x.UserId });
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "([NormalizedUserName] IS NOT NULL)");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "([NormalizedName] IS NOT NULL)");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__Certifica__idFun__236943A5",
            //    table: "CertificadoRegisto",
            //    column: "idFuncionarioEmissor",
            //    principalTable: "FuncionarioJudicial",
            //    principalColumn: "id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__Certifica__idSol__245D67DE",
            //    table: "CertificadoRegisto",
            //    column: "idSolicitacao",
            //    principalTable: "Solicitacaoregisto",
            //    principalColumn: "id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__Cidadao__idUtili__17036CC0",
            //    table: "Cidadao",
            //    column: "idUtilizador",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__Funcionar__idUti__14270015",
            //    table: "FuncionarioJudicial",
            //    column: "idUtilizador",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__logs__IDUSER__114A936A",
            //    table: "logs",
            //    column: "IDUSER",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__pagamento__idSol__2739D489",
            //    table: "pagamento",
            //    column: "idSolicitacao",
            //    principalTable: "Solicitacaoregisto",
            //    principalColumn: "id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__RegistosC__idCid__1AD3FDA4",
            //    table: "RegistosCriminal",
            //    column: "idCidado",
            //    principalTable: "Cidadao",
            //    principalColumn: "id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__Solicitac__idCid__208CD6FA",
            //    table: "Solicitacaoregisto",
            //    column: "idCidado",
            //    principalTable: "Cidadao",
            //    principalColumn: "id");
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK__Certifica__idFun__236943A5",
        //        table: "CertificadoRegisto");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__Certifica__idSol__245D67DE",
        //        table: "CertificadoRegisto");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__Cidadao__idUtili__17036CC0",
        //        table: "Cidadao");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__Funcionar__idUti__14270015",
        //        table: "FuncionarioJudicial");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__logs__IDUSER__114A936A",
        //        table: "logs");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__pagamento__idSol__2739D489",
        //        table: "pagamento");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__RegistosC__idCid__1AD3FDA4",
        //        table: "RegistosCriminal");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK__Solicitac__idCid__208CD6FA",
        //        table: "Solicitacaoregisto");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoleAspNetUser");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__Solicita__3213E83F4B4E5BC2",
        //        table: "Solicitacaoregisto");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__Registos__3213E83FA0006D4C",
        //        table: "RegistosCriminal");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__pagament__3213E83F32BFC9AE",
        //        table: "pagamento");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__logs__3214EC272ABE76E2",
        //        table: "logs");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__Funciona__3213E83FECB2DE74",
        //        table: "FuncionarioJudicial");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__Cidadao__3213E83F7C3C30EE",
        //        table: "Cidadao");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK__Certific__3213E83F5E822AA9",
        //        table: "CertificadoRegisto");

        //    migrationBuilder.DropIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers");

        //    migrationBuilder.DropIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles");

        //    migrationBuilder.DropColumn(
        //        name: "estado",
        //        table: "pagamento");

        //    migrationBuilder.DropColumn(
        //        name: "nomecompleto",
        //        table: "Cidadao");

        //    migrationBuilder.AlterColumn<bool>(
        //        name: "urgencia",
        //        table: "Solicitacaoregisto",
        //        type: "bit",
        //        nullable: true,
        //        oldClrType: typeof(bool),
        //        oldType: "bit",
        //        oldNullable: true,
        //        oldDefaultValue: false);

        //    migrationBuilder.AlterColumn<bool>(
        //        name: "pago",
        //        table: "Solicitacaoregisto",
        //        type: "bit",
        //        nullable: true,
        //        oldClrType: typeof(bool),
        //        oldType: "bit",
        //        oldNullable: true,
        //        oldDefaultValue: false);

        //    migrationBuilder.AlterColumn<DateTime>(
        //        name: "datasolicitacao",
        //        table: "Solicitacaoregisto",
        //        type: "datetime",
        //        nullable: false,
        //        oldClrType: typeof(DateTime),
        //        oldType: "datetime",
        //        oldDefaultValueSql: "(getdate())");

        //    migrationBuilder.AlterColumn<bool>(
        //        name: "cumprido",
        //        table: "RegistosCriminal",
        //        type: "bit",
        //        nullable: true,
        //        oldClrType: typeof(bool),
        //        oldType: "bit",
        //        oldNullable: true,
        //        oldDefaultValue: false);

        //    migrationBuilder.AlterColumn<int>(
        //        name: "IDUSER",
        //        table: "logs",
        //        type: "int",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(450)",
        //        oldMaxLength: 450);

        //    migrationBuilder.AlterColumn<int>(
        //        name: "idUtilizador",
        //        table: "FuncionarioJudicial",
        //        type: "int",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(450)",
        //        oldMaxLength: 450);

        //    migrationBuilder.AlterColumn<int>(
        //        name: "idUtilizador",
        //        table: "Cidadao",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(450)",
        //        oldMaxLength: 450,
        //        oldNullable: true);

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_Solicitacaoregisto",
        //        table: "Solicitacaoregisto",
        //        column: "id");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_RegistosCriminal",
        //        table: "RegistosCriminal",
        //        column: "id");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_pagamento",
        //        table: "pagamento",
        //        column: "id");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_logs",
        //        table: "logs",
        //        column: "ID");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_FuncionarioJudicial",
        //        table: "FuncionarioJudicial",
        //        column: "id");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_Cidadao",
        //        table: "Cidadao",
        //        column: "id");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_CertificadoRegisto",
        //        table: "CertificadoRegisto",
        //        column: "id");

        //    migrationBuilder.CreateTable(
        //        name: "Utilizador",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            datacriacao = table.Column<DateTime>(type: "datetime", nullable: false),
        //            nivelpermissao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            nomecompleto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
        //            senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
        //            tipoutilizador = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Utilizador", x => x.id);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_CertificadoRegisto_FuncionarioJudicial_idFuncionarioEmissor",
        //        table: "CertificadoRegisto",
        //        column: "idFuncionarioEmissor",
        //        principalTable: "FuncionarioJudicial",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_CertificadoRegisto_Solicitacaoregisto_idSolicitacao",
        //        table: "CertificadoRegisto",
        //        column: "idSolicitacao",
        //        principalTable: "Solicitacaoregisto",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Cidadao_Utilizador_idUtilizador",
        //        table: "Cidadao",
        //        column: "idUtilizador",
        //        principalTable: "Utilizador",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_FuncionarioJudicial_Utilizador_idUtilizador",
        //        table: "FuncionarioJudicial",
        //        column: "idUtilizador",
        //        principalTable: "Utilizador",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_logs_Utilizador_IDUSER",
        //        table: "logs",
        //        column: "IDUSER",
        //        principalTable: "Utilizador",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_pagamento_Solicitacaoregisto_idSolicitacao",
        //        table: "pagamento",
        //        column: "idSolicitacao",
        //        principalTable: "Solicitacaoregisto",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_RegistosCriminal_Cidadao_idCidado",
        //        table: "RegistosCriminal",
        //        column: "idCidado",
        //        principalTable: "Cidadao",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Solicitacaoregisto_Cidadao_idCidado",
        //        table: "Solicitacaoregisto",
        //        column: "idCidado",
        //        principalTable: "Cidadao",
        //        principalColumn: "id",
        //        onDelete: ReferentialAction.Cascade);
        //}
            
    }
}
