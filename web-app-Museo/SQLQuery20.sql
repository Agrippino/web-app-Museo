
SELECT DATEADD (day,-30, GETDATE())
SUM (a.QuantitaDaAcquistare) AS ProdottiVenduti
FROM
 Prodotti AS p
 INNER JOIN
Acquisti AS a
ON p.Id = a.ProdottoId
GROUP BY
p.Id;