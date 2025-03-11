using System;
using System.Collections.Generic;

namespace partners;

public partial class TypesOfProduct
{
    public int Id { get; set; }

    public string TypeOfProduct { get; set; } = null!;

    public short? ProductTypeCoefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
