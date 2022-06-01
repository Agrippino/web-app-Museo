SELECT
    p.Id,
    p.Nome,
    SUM(d.QuantitaTotale - r.QuantitaTotale) AS QuantitaTotale
FROM
    Prodotti as p
    INNER JOIN
    QuantitaAggiunte AS d
    ON d.id = p.id
    LEFT JOIN
        QuantitaAcquistate AS r
    ON d.Id = r.Id
    GROUP BY
        p.Id,
        p.Nome
    ORDER BY QuantitaTotale ASC
        ;