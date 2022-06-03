using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaAggiunteMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaAggiunte
                                AS
                                SELECT
                                    p.Id,
									p.Nome,
                                    SUM(ISNULL(r.QuantitaDaAggiungere,0)) AS QuantitaTotale
                                FROM
                                    Rifornimenti AS r
                                    RIGHT JOIN
                                        Prodotti AS p
                                    ON p.Id = r.ProdottoId
                                    GROUP BY
                                        p.Id, p.Nome;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaAggiunte;
            ");

        }
    }
}
