using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class RifornimentoEditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRifornimento",
                table: "Rifornimenti",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornitore",
                table: "Rifornimenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRifornimento",
                table: "Rifornimenti");

            migrationBuilder.DropColumn(
                name: "NomeFornitore",
                table: "Rifornimenti");
        }
    }
}
