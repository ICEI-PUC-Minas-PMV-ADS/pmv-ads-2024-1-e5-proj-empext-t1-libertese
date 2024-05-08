using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaEmpresaParceira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valoraporte",
                table: "EmpresasParceiras",
                newName: "ValorAporte");

            migrationBuilder.RenameColumn(
                name: "valoradicional",
                table: "EmpresasParceiras",
                newName: "ValorAdicional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorAporte",
                table: "EmpresasParceiras",
                newName: "valoraporte");

            migrationBuilder.RenameColumn(
                name: "ValorAdicional",
                table: "EmpresasParceiras",
                newName: "valoradicional");
        }
    }
}
