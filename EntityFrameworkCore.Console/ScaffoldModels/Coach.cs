using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Console.ScaffoldModels;

public partial class Coach
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
