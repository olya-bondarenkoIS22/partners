using System;
using System.Collections.Generic;

namespace partners;

public partial class TypesOfMaterial
{
    public int Id { get; set; }

    public string TypeOfMaterial { get; set; } = null!;

    public short? MaterialScrapPercentage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
