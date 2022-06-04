Create VIEW ConteggioLike
                                AS
                                SELECT
                                    p.Id,
                                    p.Nome,
                                    p.Immagine,
                                    SUM(ISNULL(l.LikeInseriti,0)) AS LikeTotali
                                FROM
                                    Likes AS l
                                    RIGHT JOIN
                                        Prodotti AS p
                                    ON p.Id = l.ProdottoId
                                    GROUP BY
                                        p.Id, p.Nome, p.Immagine;