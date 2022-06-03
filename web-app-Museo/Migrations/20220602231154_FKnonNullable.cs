using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class FKnonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisti_Prodotti_ProdottoId",
                table: "Acquisti");

            migrationBuilder.DropForeignKey(
                name: "FK_Rifornimenti_Prodotti_ProdottoId",
                table: "Rifornimenti");

            migrationBuilder.AlterColumn<int>(
                name: "ProdottoId",
                table: "Rifornimenti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdottoId",
                table: "Acquisti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisti_Prodotti_ProdottoId",
                table: "Acquisti",
                column: "ProdottoId",
                principalTable: "Prodotti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rifornimenti_Prodotti_ProdottoId",
                table: "Rifornimenti",
                column: "ProdottoId",
                principalTable: "Prodotti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisti_Prodotti_ProdottoId",
                table: "Acquisti");

            migrationBuilder.DropForeignKey(
                name: "FK_Rifornimenti_Prodotti_ProdottoId",
                table: "Rifornimenti");

            migrationBuilder.AlterColumn<int>(
                name: "ProdottoId",
                table: "Rifornimenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProdottoId",
                table: "Acquisti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisti_Prodotti_ProdottoId",
                table: "Acquisti",
                column: "ProdottoId",
                principalTable: "Prodotti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rifornimenti_Prodotti_ProdottoId",
                table: "Rifornimenti",
                column: "ProdottoId",
                principalTable: "Prodotti",
                principalColumn: "Id");
        }
    }
}
