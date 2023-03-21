# Linq Query Syntax

To start with, Grab the database and ToArray it to a class database.

Then call IEnumerable<ClassName> and set the sql conditions on it

Then use an iterator on the array and then the array should return the values that are met in the array

Must be done within same code scope, the ienumerator will be lost after the scope

LinQ

L - Language 
In - Integrated
Q - Query

## LinQ Method Syntax

Method syntax is like the name suggests instead of the regular query language where you have to write from, select, ect. There excists methods that each partial class, that is made with entity framework, has access to which do the same function but they need lambda expressions to pass in data because they are an extension.


    var methodSyntax = db.Customers //Uses methods to call common queries
        .Where(c => c.City == "London")
        .OrderBy(c => c.ContactName);

**Important** The syntax only setup the query, it needs an iterator in order to apply it. 

## Lambda Expressions

Lambda expressions are done with the => sign, to do abstract methods.

    static bool IsOdd(int num) => num % 2 != 0; //Think of => as {}

    var customerNames = db.Customers
        .Where(cust => cust.ContactName.StartsWith("A"));

    Console.WriteLine(nums.Count(delegate (int num) { return num % 2 == 0; })); 
