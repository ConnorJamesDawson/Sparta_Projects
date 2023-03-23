using EF_ModelFirst.Model;
using System.Collections.Generic;

namespace EF_ModelFirst;

class Program
{
    static void Main(string[] args)
    {

        using (var db = new SouthwindContext())
        {
            //SeedDatabase.SeedCustomers(db);
            SeedDatabase.SeedOrder(db);
            SeedDatabase.SeedOrderDetails(db);
        }
    }
}
