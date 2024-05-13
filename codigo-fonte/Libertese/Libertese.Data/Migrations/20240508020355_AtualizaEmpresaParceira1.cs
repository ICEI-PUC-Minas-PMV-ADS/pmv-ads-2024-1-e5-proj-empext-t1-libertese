using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaEmpresaParceira1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ValorAporte",
                table: "EmpresasParceiras",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<float>(
                name: "ValorAdicional",
                table: "EmpresasParceiras",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAporte",
                table: "EmpresasParceiras",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorAdicional",
                table: "EmpresasParceiras",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
