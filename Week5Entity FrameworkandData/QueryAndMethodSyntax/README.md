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

## GitHub Questions - Linq and Lambda

- LINQ uses two syntaxes - Name and describe them

Query Syntax uses raw sql commands to query tables

Method Syntax uses Methods in place of sql commands with information passed in with lambda expressions

- When is a LINQ query executed?

LinQ querys are executed with an iteator that is within the same scope as the query

- What is a Lambda expression?  Why is it used in LINQ queries?

A lambda expression is a way of defining an anonymous function that can be passed around as a variable or as a parameter to a method call. 

Many LINQ methods take a function (called a delegate) as a parameter.

- What does x => x * x mean?

Return the product of X where X is the value passed to the method

- What is an anonymous method?

An anonymous method is a nunamed method 

- What is Expression body syntax?

An expression-bodied method consists of a single expression that returns a value whose type matches the method's return type, or, for methods that return void, that performs some operation.

   public override string ToString() => $"{fname} {lname}".Trim();
