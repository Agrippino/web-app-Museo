using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaDisponibileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaDisponibili
                                AS
                                SELECT
                                    p.Id,
                                    SUM(d.QuantitaTotale - p.QuantitaTotale) AS QuantitaTotale
                                FROM
                                    QuantitaAcquistate AS p
                                    INNER JOIN
                                        QuantitaAggiunte AS d
                                    ON p.Id = d.Id
                                    GROUP BY
                                        p.Id;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaDisponibili;
            ");
        }
    }
}
