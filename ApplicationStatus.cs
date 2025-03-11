using System;
using System.Collections.Generic;

namespace partners;

public partial class ApplicationStatus
{
    public int Id { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<ApplicationStatusHistory> ApplicationStatusHistories { get; set; } = new List<ApplicationStatusHistory>();
}
