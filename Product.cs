using System;
using System.Collections.Generic;

namespace partners;

public partial class Product
{
    public int Id { get; set; }

    public int IdImplementationHistory { get; set; }

    public int IdTyoeOfProduct { get; set; }

    public int IdTypeOfMaterials { get; set; }

    public string Name { get; set; } = null!;

    public List<string> Article { get; set; } = null!;

    public short MinPrice { get; set; }

    public short Price { get; set; }

    public virtual ImplementationHistory IdImplementationHistoryNavigation { get; set; } = null!;

    public virtual TypesOfProduct IdTyoeOfProductNavigation { get; set; } = null!;

    public virtual TypesOfMaterial IdTypeOfMaterialsNavigation { get; set; } = null!;

    public virtual ICollection<RequestProduct> RequestProducts { get; set; } = new List<RequestProduct>();
}
