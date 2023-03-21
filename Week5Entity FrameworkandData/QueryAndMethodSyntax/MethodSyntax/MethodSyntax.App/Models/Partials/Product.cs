using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSyntax.App.Models;

public partial class Product
{

    public override string ToString()
    {
        return $"{ProductId} - {ProductName} - {ReorderLevel} - {QuantityPerUnit}";
    }

}
