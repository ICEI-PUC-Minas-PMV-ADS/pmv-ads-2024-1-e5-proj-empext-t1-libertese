using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialFornecedorList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialFornecidoId",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int[]>(
                name: "MaterialFornecidoIds",
                table: "Fornecedores",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialFornecidoIds",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "MaterialFornecidoId",
                table: "Fornecedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
