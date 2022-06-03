Create VIEW ClassificaProdottiProvaSimone2
                       AS
                    SELECT
                    p.Id,
                    p.Nome,
                    p.Immagine,
                    SUM(a.QuantitaDaAcquistare) AS ProdottiVenduti
                    FROM
                     INNER JOIN
                    GROUP BY
                    p.Nome,
                    p.Id,
