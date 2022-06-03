using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class QuantitaDisponibileMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW QuantitaDisponibili
                                AS
                                SELECT
                                    p.Id,
                                    p.Nome,
                                    p.Immagine,
                                    c.Nome AS Categoria,
                                    SUM(d.QuantitaTotale - r.QuantitaTotale) AS QuantitaTotale
                                FROM
                                    QuantitaAcquistate AS r
                                    INNER JOIN
                                        QuantitaAggiunte AS d
                                    ON r.Id = d.Id
                                    INNER JOIN
                                        Prodotti AS p
                                    ON d.Id = p.Id
                                    INNER JOIN
                                        Categorie AS c
                                    ON p.CategoriaId = c.Id
                                    GROUP BY
                                        p.Id,p.Nome,p.Immagine,c.Nome
                                    ORDER BY
                                        QuantitaTotale 
                                    OFFSET 0 ROWS;");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaDisponibili;
            ");
        }
    }
}
