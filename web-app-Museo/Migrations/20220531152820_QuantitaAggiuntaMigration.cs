using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaAggiuntaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaAggiunte
                                AS
                                SELECT
                                    p.Id,
                                    SUM(r.QuantitaDaAggiungere) AS QuantitaTotale
                                FROM
                                    Rifornimenti AS r
                                    INNER JOIN
                                        Prodotti AS p
                                    ON p.Id = r.ProdottoId
                                    GROUP BY
                                        p.Id;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaAggiunte;
            ");
        }
    }
}
