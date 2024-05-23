using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCamposFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CursoLibertese",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Penitenciaria",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pessoareclusa",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CursoLibertese",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Penitenciaria",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Pessoareclusa",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Funcionarios");
        }
    }
}
