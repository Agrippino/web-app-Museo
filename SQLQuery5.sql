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
                                        p.Id, p.Nome;