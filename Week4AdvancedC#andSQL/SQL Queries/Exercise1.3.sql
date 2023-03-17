select P.ProductName, S.CompanyName ,S.Country
from dbo.Products P
join dbo.Suppliers S
	on P.SupplierID = S.SupplierID
where P.QuantityPerUnit LIKE '%bottle%'