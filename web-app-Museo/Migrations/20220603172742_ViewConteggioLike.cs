using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_Museo.Migrations
{
    public partial class ViewConteggioLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create VIEW ConteggioLikes
                                AS
                                SELECT
                                    p.Id,
                                    p.Nome,
                                    p.Immagine,
                                    SUM(ISNULL(l.LikeInseriti, 0)) AS LikeTotali
                                FROM
                                    Likes AS l
                                    RIGHT JOIN
                                        Prodotti AS p
                                    ON p.Id = l.ProdottoId
                                    GROUP BY
                                        p.Id, p.Nome, p.Immagine;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            drop view ConteggioLikes;
            ");
        }
    }
}
