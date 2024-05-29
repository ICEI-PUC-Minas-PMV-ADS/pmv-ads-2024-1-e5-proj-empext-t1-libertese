using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libertese.Data.Migrations
{
    /// <inheritdoc />
    public partial class ValorPrecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaBancariaId",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "DataEmissao",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Receitas");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Precos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Precos");

            migrationBuilder.AddColumn<int>(
                name: "ContaBancariaId",
                table: "Receitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataEmissao",
                table: "Receitas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataVencimento",
                table: "Receitas",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
