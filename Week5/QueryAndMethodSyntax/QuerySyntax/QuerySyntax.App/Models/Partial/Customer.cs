using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuerySyntax.App.Models;

public partial class Customer
{

    public override string ToString()
    {
        return $"{CustomerId} - {ContactName} - {CompanyName} - {City}";
    }

}
