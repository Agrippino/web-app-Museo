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
                                    OFFSET 0 ROWS;