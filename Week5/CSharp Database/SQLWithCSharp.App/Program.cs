using Microsoft.Data.SqlClient;
namespace SQLWithCSharp.App;

internal class Program
{

    static void Main()
    {
        var connectionString =
            "Data Source = (localdb)\\MSSQLLocalDB; " +
            "Initial Catalog = Northwind; " +
            "Integrated Security = True; " +
            "Connect Timeout = 30; " +
            "Encrypt = False; " +
            "TrustServerCertificate = False; " +
            "ApplicationIntent = ReadWrite; " +
            "MultiSubnetFailover = False;";

        OpenConnection(connectionString);

    }

    static void OpenConnection(string connectionString)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            Console.WriteLine(conn.State);

            Read(conn);

            Create(conn);

            Update(conn);

            Delete(conn);
        }
    }

    static void Read(SqlConnection conn)
    {
        using (var command = new SqlCommand("SELECT * FROM Customers;", conn))
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                Console.WriteLine(
                $"Customer {sqlReader["ContactTitle"]} - {sqlReader["ContactName"]} " +
                $"has ID {sqlReader["CustomerId"]} " +
                $"and lives in {sqlReader["City"]}"
                );
            }
            sqlReader.Close();
        }
    }

    static void Create(SqlConnection conn)
    {
        string sql = $"INSERT INTO Customers(" +
        $"CustomerID, " +
        $"ContactName, " +
        $"CompanyName, " +
        $"City" +
        $") VALUES (" +
        $"'WINDB', " +
        $"'Phil Windridge', " +
        $"'Birmingham', " +
        $"'Sparta Global')"; 

        int affected;

        using (var command = new SqlCommand(sql, conn))
        {
            affected = command.ExecuteNonQuery();
        }
    }
    static void Update(SqlConnection conn)
    {
        string sql = $"Update Customers Set City = 'Berlin' where CustomerID = 'WINDR';";

        int affected;

        using (var command = new SqlCommand(sql, conn))
        {
            affected = command.ExecuteNonQuery();
        }
    }
    static void Delete(SqlConnection conn)
    {
        string sql = $"Delete From Customers Where CustomerID = 'WINDR';";

        int affected;

        using (var command = new SqlCommand(sql, conn))
        {
            affected = command.ExecuteNonQuery();
        }
    }
}