using System;
using System.Collections.Generic;

namespace QuerySyntax.App.Models;

public partial class SpartanTest
{
    public int SpartanId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public string? Phone { get; set; }

    public string? University { get; set; }
}
