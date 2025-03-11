using System;
using System.Collections.Generic;

namespace partners;

public partial class RequestProduct
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdRequest { get; set; }

    public int CountOfUnitsOrdered { get; set; }

    public DateOnly DateOfManufacture { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Request IdRequestNavigation { get; set; } = null!;
}
