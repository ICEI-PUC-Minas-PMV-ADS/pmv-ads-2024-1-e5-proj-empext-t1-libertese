using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposFornecedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DadosBancarios",
                table: "Fornecedores",
                newName: "TelefoneDois");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Fornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DadosBancariosId",
                table: "Fornecedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialFornecidoId",
                table: "Fornecedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DadosBancariosId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "MaterialFornecidoId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "TelefoneDois",
                table: "Fornecedores",
                newName: "DadosBancarios");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
