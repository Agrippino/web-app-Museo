using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaAcquistataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaAcquistate
                                AS
                                SELECT
                                    p.Id,
                                    SUM(a.QuantitaDaAcquistare) AS QuantitaTotale
                                FROM
                                    Acquisti AS a
                                    INNER JOIN
                                        Prodotti AS p
                                    ON p.Id = a.ProdottoId
                                    GROUP BY
                                        p.Id;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaAcquistate;
            ");
        }
    }
}
