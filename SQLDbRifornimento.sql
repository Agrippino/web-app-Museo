CREATE VIEW quantitaDisponibile
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
GROUP BY r.DataRifornimento,
         p.Id,
         p.Nome;