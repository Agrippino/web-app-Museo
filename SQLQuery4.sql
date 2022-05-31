Create VIEW QuantitaAggiunta
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
                    p.Id;