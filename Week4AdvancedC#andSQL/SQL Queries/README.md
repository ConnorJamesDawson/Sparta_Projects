# SQL

## General notes

SQL doesn't care about lines or spaces (except in names) so Select firstname from customer; works the same as:

select firstname
from customer

- ; are used to end a statement so it's a good habit to have to seperate code

## Sequence statements

SQL has a stric **syntax sequence** from which it has to be wrote:

- Select
- Distinct
- From
- Where
- Group By
- Having
- Order By

But this syntax sequence is not how SQL reads the code, the **Processing Sequence** is:

- From
- Where
- Group By
- Having
- Select
- Distinct
- Order By


## Select

Simplest statement there is, selecting a (column) from (table) (replace with actual names)

If you want multiple coumns you need to seperate the columns by a , so firstname, lastname, phone_number

If you want to label a column under a different name you need to have; Select firstname AS First Name

If you want all columns just do Select *

UPPER() - ToUpper()
LOWER() - ToLower()

## Where

Where clause is used to retrieve specific rows from the table so; SELECT firstname as "First Name", lastname as "Last Name", city as "City" FROM customer WHERE city = 'Montpellier';

**Important** Where needs the ' ' for the earch otherwise you're trying to set the name

Where needs a comparison operator on the statement, so basically it's an if statement so it uses the same comparison operators

AND is &&, OR is ||

### Wildcards/Like

so for if you don't want an exact match you need to use LIKE where is will search for that phrase in a particlar way based on the Wildcard used:

- 'L__A' - _ is used to substitute letters so this will return all 4 letter names where it starts with L and ends in A
- L% - The % sign is used to sreach for anything after, stands in for 0 or more, so any value that starts with L will be returned
- %H% - This will look for any value that contains H, doesn't matter where it is
- IPhone [345] - searchs for the match of those values of 3,4,5
- IPhone [^345] - ^ is like a not so it searchs for the values that do not match those values of 3,4,5
- between 50 and 100 - is used to short hand price >= 50 and price <= 100
- In ('','') - is used to create a list of ORs for code to look at instead of an OR chain

### Null

Null is not null like in c#, firstname = Null will not work, you need to use firstname is null.

## Top

**Needs to be the first thng in select**

Top works as expected looks at the top values given the criteria:

- top 5 * - means top 5 values in the table
- top 5 firstname - top 5 values in firstname

## Order By

order by lastname asc - orders last name in ascending fashion
order by lastname desc - orders last name in descending fashion

## Distinct

Removes duplicate values from the column

select distinct city, would return every seperate instance of city

## Concatonate

To concat in regular sql; SELECT firstname + ' ' + lastname as "Full Name" FROM customer;

To concat in codinGame sql; SELECT firstname || ' ' || lastname as "Full Name" FROM customer;

## Arithmetic

You can use arithmetic to create a column

SELECT name as "Name", price as "Price", available_stock as "Available Stock", price * available_stock as "Total Value" FROM product;

## Case

Case is a switch statement

case 
    when available_stock < 20 then 'Low Stock!'
    when available_stock < 100 then 'Limited Stock'
    else 'Well-Stocked'
end as "STOCK LEVEL"

## Aggregation

Sum - Sum of column
AVG - Average of column
Min - Minimum value
Max - Max value
Count - The amount of values that are not null in column

## Group By

Used to group results together based on a column

SELECT city as "City", count(city) as "Customer Count"
FROM customer
group by city - This is grouping each city a unique row
order by count(city) desc, city asc; - This is ordering the column by the highest first lowest last with any ties decided by alphabetical order

## Having

having is not where, it is used in conjuction with group by to put a conditional modifier on it

SELECT product_category_id as "Category ID", max(price) as "Maximum Price"
FROM product
where product_category_id is not null
group by product_category_id
having min(available_stock) < 100;

## Join

When joining tables the 'Left table' is the first table specified.

### Types of Join

Left Join - will return call rows in the left table and return rows from the right table that match with the ones in the left table
Right Join - is the opposite , don't use nless there is a good reason

Inner Join - Will return rows from each table only if there is a match in the other table
Outer Join - Will return all rows from each table regardless of wether there is a match or not

So to join two tables together that have the same value you need to do;

SELECT student.firstname, course.coursename
FROM student
inner join course
on student.COURSE_ID = course.ID

If you want all values from one table and only the matching rows of the second table you use left join

SELECT s.firstname as "First Name", c.coursename as "Course"
FROM student s
left join course c
on s.COURSE_ID = c.ID;

## Table Aliases

Think of instantiation, define the table then give it a nickname that the system will use, not needed but very useful for readability

SELECT s.firstname as "First Name", c.coursename as "Course"
FROM student s
left join course c
on s.COURSE_ID = c.ID;

from student s

## Multiple joins

Multiple joins can seem tricky but you just need to find the common variables linking the two tables

SELECT po.date as "Date", UPPER(c.firstname) || ' ' || c.lastname as "Customer", p.name as "Product", pc.name as "Product Category" 
FROM purchase_order po
join customer c
    on po.customer_id = c.customer_id
join order_product op
    on po.order_id = op.order_id
join product p
    on op.product_id = p.product_id
join product_category pc
    on p.product_category_id = pc.product_category_id
order by po.date asc

In this example each table has a corresponding ID to link each table

# GitHub Questions

- What is an ERD?
An entity relationship diagram (ERD), also known as an entity relationship model, is a graphical representation that depicts relationships among tables in a database system.

- What is a primary key?
A primary key is used to identify different rows of information in a table

- What is a foreign key?
A foreign key is a key that links the current table to another table in a database

- What is the difference between a foreign and primary key?
A primary key is the current tables primary identifier for its rows, a foreign key is a primary key of another table in the database

- Explain Normalisation.
Normalization is the process to eliminate data redundancy and enhance data integrity in the table. Normalization also helps to organize the data in the database.

- What command would you use if you want to add a table?
CREATE TABLE [dbo].[SpartanTest] (
    [SpartanID] INT     NOT NULL IDENTITY,
    CONSTRAINT [PK_SpartanID] PRIMARY KEY CLUSTERED ([SpartanID] ASC)
);

- What command would you use if you want to add a column to a table
ALTER TABLE dbo.SpartanTest
ADD Email varchar(255);

- What command would you use if you want to delete a row of data
ALTER TABLE dbo.SpartanTest
DROP COLUMN Email;

- What command would you use if you want to insert data into a table
insert into dbo.Spartan (FirstName, LastName, Age)
values ('Connor', 'Dawson', '24')

- What are DML, DDL, DCL and TCL?
DDL - Data Definition Language. DQL - Data Query Language. DML - Data Manipulation Language. DCL - Data Control Language. TCL - Transaction Control Language.

- If you wanted to select only the top 10 highest earners in a table of millionaires, what query would you write?
Select Top 10 M.Earnings, M.Name
from dbo.Millionaires M

- What is a wildcard?
A wildcard is used in conjunction with the Where keyword to sort through tables for if you want the likeness of specific information such as every entry in name that begins with J

where C.Name like 'J%'

- What is concatenation (with example)
Concatenation is joining two tables together with the + operand

Select C.firstname + ' ' + C.lastname as "Full Name"
from dbo.Customer C

- What query would I write if I want to find out all customers who do not have city listed in a table
Select * From dbo.Customers where City is null

- What does the arithmetic operator % do?
% - modulo, returns the remainder of a divide

- What does NULL mean?
null means there is no information currently set to that field

- Can a primary key be NULL?
No a primary key needs to be filled in when adding data into a table

- How do I select all the values starting with the letter C?
Select *
From dbo.Customers C
Where C.Name Like 'C%'

- When is the GROUP BY keyword used?

Used to group results together based on a column

Select Count(C.ContactTitle) as "Number of Contacts by Sales Title", C.ContactTitle
From dbo.Customers C
Group By C.ContactTitle
Order By Count(C.ContactTitle) desc