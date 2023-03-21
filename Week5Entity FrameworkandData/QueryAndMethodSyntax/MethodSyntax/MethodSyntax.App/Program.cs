using MethodSyntax.App.Models;

namespace MethodSyntax.App;

internal class Program
{
    static void Main()
    {
        using (var db = new NorthwindContext())
        {
            MethodSyntaxWithLambda.FindCustomersWithContactNameBeginningWithChar(db, 'A');
            Console.WriteLine(" --- ");
            MethodSyntaxWithLambda.GroupUnitsInStockBySupplierId(db);
            Console.WriteLine(" --- ");
            MethodSyntaxWithLambda.OrderProductsByQuantityPerUnit(db);
        }
    }

    static bool IsOdd(int num) => num % 2 != 0; //Think of => as {}

    static void QuerySyntax(NorthwindContext db)
    {
        var querySyntax =
        from c in db.Customers
        where c.City == "London"
        orderby c.ContactName
        select c;
    }
    
    static void MethodSyntax(NorthwindContext db)
    {
        var methodSyntax = db.Customers //Uses methods to call common queries
            .Where(c => c.City == "London")
            .OrderBy(c => c.ContactName);

        var methodSyntax2 = db.Customers
            .Count(c => c.City == "London" || c.City == "Berlin");
    }

    static void LambdaBasics()
    {
        var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

        Console.WriteLine(nums.Count(c => c % 2 == 0));
        Console.WriteLine(nums.Count(delegate (int num) { return num % 2 == 0; })); //Abstract methods
        Console.WriteLine("---");
        Console.WriteLine(nums.Count(IsOdd));
        Console.WriteLine("---");
        Console.WriteLine(nums.Count(c => c <= 4));
    }
}