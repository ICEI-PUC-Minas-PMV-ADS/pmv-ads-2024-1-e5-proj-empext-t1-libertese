using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddValoresDespesas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Despesas");
        }
    }
}
