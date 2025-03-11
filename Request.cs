using System;
using System.Collections.Generic;

namespace partners;

public partial class Request
{
    public int Id { get; set; }

    public int IdPartner { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public short OrderAmount { get; set; }

    public short PrepaymentAmount { get; set; }

    public virtual ICollection<ApplicationStatusHistory> ApplicationStatusHistories { get; set; } = new List<ApplicationStatusHistory>();

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual ICollection<RequestProduct> RequestProducts { get; set; } = new List<RequestProduct>();
}
