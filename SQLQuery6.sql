Create VIEW ClassificaProdottiProvaSimone2
                       AS
                    SELECT
                    p.Id,
                    p.Nome,
                    p.Immagine,
                    SUM(a.QuantitaDaAcquistare) AS ProdottiVenduti
                    FROM
                     Prodotti AS p
                     INNER JOIN
                    Acquisti AS a
                    ON p.Id = a.ProdottoId
                    WHERE a.Data < GETDATE() AND a.Data > DATEADD(day, -30, GETDATE())
                    GROUP BY
                    p.Nome,
                    p.Id,
                    p.Immagine
                    ORDER BY
                    ProdottiVenduti DESC offset 0 ROWS;