Create VIEW quantitaDisponibile
AS
SELECT
    p.Id,
    SUM(r.QuantitaDaAggiungere) AS Totale
FROM
    Rifornimenti AS r
    INNER JOIN
        Prodotti AS p
    ON p.Id = r.ProdottoId
    GROUP BY
        p.Id;