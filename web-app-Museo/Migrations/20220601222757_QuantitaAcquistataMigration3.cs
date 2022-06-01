using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaAcquistataMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaAcquistate
                                AS
                                SELECT
                                    p.Id,
                                    p.Nome,
                                    SUM(ISNULL(a.QuantitaDaAcquistare,0)) AS QuantitaTotale
                                FROM
                                    Acquisti AS a
                                    RIGHT JOIN
                                        Prodotti AS p
                                    ON p.Id = a.ProdottoId
                                    GROUP BY
                                        p.Id, p.Nome;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaAcquistate;
            ");
        }
    }
}
