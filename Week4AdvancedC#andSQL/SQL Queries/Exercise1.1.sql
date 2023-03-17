select c.CustomerID, c.CompanyName, c.City,c.Address + ' ' + c.City + ' ' + c.PostalCode as "Full Address"
from dbo.Customers c
where c.City = 'Paris' or c.City = 'London';