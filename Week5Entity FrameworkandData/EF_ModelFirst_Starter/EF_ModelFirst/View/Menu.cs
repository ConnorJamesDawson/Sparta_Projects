using Microsoft.EntityFrameworkCore.Query;
using System;

namespace EF_ModelFirst;

public class Menu
{

    public void PrintOpeningMessage(SouthwindContext db)
    {
        Console.WriteLine(" ---- Welcome! ----");
        Console.WriteLine("Please choose an options to go with:\n 1: Add Customer to Database \n2: Edit user in Database \n" +
                          "3: Delete User from the database \n4: Print All customers in database");

        HandleInput.ReadInput(db);
    }

}
