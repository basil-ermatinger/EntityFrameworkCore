using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Console.ScaffoldModels;

public partial class Team
{
    public int TeamId { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedDate { get; set; }
}
