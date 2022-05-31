using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class migrazioneConView1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(@"CREATE VIEW QuantitaDisponibili
                                        AS
                                        SELECT
                                            r.DataRifornimento,
                                            p.Id,
                                            p.Nome,
                                            SUM(QuantitaDaAggiungere + p.QuantitaDisponibile) AS QuantitaTotale
                                        FROM
                                            Rifornimenti AS r
                                        INNER JOIN Prodotti AS p
                                            ON p.Id = r.ProdottoId
                                        GROUP BY 
                                         r.DataRifornimento,
                                        p.Id,
                                      p.Nome;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view QuantitaDisponibili;
            ");
        }
    }
}
