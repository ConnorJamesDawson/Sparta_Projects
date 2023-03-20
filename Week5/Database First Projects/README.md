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

