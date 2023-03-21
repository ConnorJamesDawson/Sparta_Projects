using System;
using System.Collections.Generic;

namespace QuerySyntax.App.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
