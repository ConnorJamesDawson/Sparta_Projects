select count(P.CategoryID) as "Number of Products", C.CategoryName
from dbo.Products P
join dbo.Categories C
	on P.CategoryID = C.CategoryID
group by C.CategoryName
order by count(P.CategoryID) desc;