using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoDeIdiomas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    AnoLetivo = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_turma", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_turma_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_matricula",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_matricula", x => new { x.TurmaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_tb_matricula_tb_aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "tb_aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_matricula_tb_turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "tb_turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Portugues" },
                    { 2, "Ingles" },
                    { 3, "Espanhol" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_matricula_AlunoId",
                table: "tb_matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_turma_CursoId",
                table: "tb_turma",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_matricula");

            migrationBuilder.DropTable(
                name: "tb_aluno");

            migrationBuilder.DropTable(
                name: "tb_turma");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
