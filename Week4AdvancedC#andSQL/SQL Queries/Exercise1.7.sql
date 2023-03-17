select OD.OrderID, MAX(OD.Discount) as "Discount"
from dbo.[Order Details] OD
group by OD.OrderID, OD.Discount
having OD.Discount = MAX(OD.Discount)
order by OD.Discount desc

