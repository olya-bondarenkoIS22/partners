using System;
using System.Collections.Generic;

namespace partners;

public partial class TypeOfPartner
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
