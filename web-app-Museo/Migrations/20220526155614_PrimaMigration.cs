using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class PrimaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descrizione = table.Column<string>(type: "Text", maxLength: 400, nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    QuantitaDisponibile = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotti_Categorie_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Acquisti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitaDaAcquistare = table.Column<int>(type: "int", nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acquisti_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rifornimenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantitaDaAggiungere = table.Column<int>(type: "int", nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifornimenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rifornimenti_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisti_ProdottoId",
                table: "Acquisti",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_CategoriaId",
                table: "Prodotti",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rifornimenti_ProdottoId",
                table: "Rifornimenti",
                column: "ProdottoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisti");

            migrationBuilder.DropTable(
                name: "Rifornimenti");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
