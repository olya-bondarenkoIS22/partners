using System;
using System.Collections.Generic;

namespace partners;

public partial class ImplementationHistory
{
    public int Id { get; set; }

    public int IdProduct { get; set; }

    public int IdPartner { get; set; }

    public int Count { get; set; }

    public DateOnly DateOfSale { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
