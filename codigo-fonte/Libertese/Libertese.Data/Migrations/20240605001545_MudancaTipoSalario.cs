using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class MudancaTipoSalario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salario",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Funcionarios",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
