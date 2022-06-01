Create VIEW ClassificaProdotti
AS
SELECT
p.Id,
SUM (a.QuantitaDaAcquistare) AS ProdottiVenduti
FROM
 Prodotti AS p
 INNER JOIN
Acquisti AS a
ON p.Id = a.ProdottoId
WHERE a.Data < GETDATE() AND a.Data > DATEADD (day,-30, GETDATE()) 
GROUP BY 
p.Id
ORDER BY 
ProdottiVenduti offset 0 ROWS;
