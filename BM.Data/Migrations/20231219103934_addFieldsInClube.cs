using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BM.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFieldsInClube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Clubes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "Clubes",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Clubes");

            migrationBuilder.DropColumn(
                name: "DataUltimaAtualizacao",
                table: "Clubes");
        }
    }
}
