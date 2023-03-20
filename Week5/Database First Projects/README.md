# Database First

To create the "" Scaffold you need a connection string which can be found by right clicking a databse, click properties and look for it in General

Then the Scaffold command looks like this

Scaffold-DbContext 
"Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=Academy;
Integrated Security=True;
Connect Timeout=30;
Encrypt=False;
Trust Server Certificate=False;
Application Intent=ReadWrite;
Multi Subnet Failover=False" 

Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Where in the Initial Catalogue will change to the database being read and the data source will change per mechine.

# GitHub Questions
 
- What are the advantages of using EF over raw SQL?

Entity Framework makes it easier for programmers to perform create, read, update and delete (CRUD) operations by supporting databases. 
It also makes it easier for developers to perform unit testing by keeping in-memory tables.
You can check the changes before they are saved to the server.

- What is a connection string used for / what information does it contain?

A connection string is a string that specifies information about a data source and the means of connecting to it. It is passed in code to an underlying driver or provider in order to initiate the connection.

It can contain: the server name, the database name, a user name and a user password.

- In the context of Entity Framework, what does scaffolding mean?

Scaffolding a database produces an Entity Framework model from an existing database. The resulting entities are created and mapped to the tables in the specified database.

- When a class is generated from a database, what does it contain?

The class contains properties that are already contained in the database and wether those properties are nullabale or not. These properties are contained in a partial class

- What does the DbContext class contain?

A DbContext instance represents a combination of the Unit Of Work and Repository patterns such that it can be used to query from a database and group together changes that will then be written back to the store as a unit.

The DbContext allows you to link your model properties to your database with a connection string.

- How are 1 to many relationships represented in the code model?

“HasMany” and “WithMany” method is used to define one-to-many or many-to-many relation in entity framework.

- What is the using keyword used for?

The using keyword has two major uses:

The using statement defines a scope at the end of which an object is disposed.

The using directive creates an alias for a namespace or imports types defined in other namespaces.

- What is meant by a partial class and why is it useful?

It provides a special ability to implement the functionality of a single class into multiple files and all these files are combined into a single class file when the application is compiled. This is good for when multiple developers want to work on the same class but different files.

- What do we mean by the term model first approach to EF?

Model First allows you to create a new model using the Entity Framework Designer and then generate a database schema from the model.

- What are EF Migrations?

The migrations feature in EF Core provides a way to incrementally update the database schema to keep it in sync with the application's data model while preserving existing data in the database.

- Using EF, how do you update an object’s data in the database?

First retrieve the instance of the object, then change/set the property desired, and then save the database to save the changes.
