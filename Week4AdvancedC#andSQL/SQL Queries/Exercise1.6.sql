select Count(O.Freight) as "How many orders have freight over 100"
from dbo.Orders O
where O.Freight > 100 and O.ShipCountry = 'USA' or O.ShipCountry = 'UK'