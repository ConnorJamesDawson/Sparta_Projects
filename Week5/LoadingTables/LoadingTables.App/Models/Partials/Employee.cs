using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingTables.App.Models;

public partial class Employee
{

    public override string ToString()
    {
        return $"{TitleOfCourtesy} {FirstName} {LastName} {City}";
    }

}
