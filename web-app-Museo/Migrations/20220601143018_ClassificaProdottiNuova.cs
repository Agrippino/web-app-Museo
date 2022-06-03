using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class ClassificaProdottiNuova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW ClassificaProdotti
                       AS
                    SELECT
                    p.Id,
                    p.Nome,
                    p.Immagine,
                    SUM(a.QuantitaDaAcquistare) AS ProdottiVenduti
                    FROM
                     Prodotti AS p
                     INNER JOIN
                    Acquisti AS a
                    ON p.Id = a.ProdottoId
                    WHERE a.Data < GETDATE() AND a.Data > DATEADD(day, -30, GETDATE())
                    GROUP BY
                    p.Nome,
                    p.Id,
                    p.Immagine
                    ORDER BY
                    ProdottiVenduti DESC offset 0 ROWS;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view ClassificaProdotti;
            ");
        }
    }
}
