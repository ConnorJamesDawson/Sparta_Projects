Select Count(C.ContactTitle) as "Number of Contacts by Sales Title", C.ContactTitle
From dbo.Customers C
Group By C.ContactTitle
Order By Count(C.ContactTitle) desc
