select E.EmployeeID, E.TitleOfCourtesy + ' ' + E.FirstName + ' ' + E.LastName as "Full Name", E.ReportsTo as "Reports To Manager ID", R.FirstName + ' ' + R.LastName as "Managers name"
from dbo.Employees E
	inner join dbo.Employees R
	on E.ReportsTo = R.EmployeeID
Order by E.ReportsTo