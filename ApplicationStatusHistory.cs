using System;
using System.Collections.Generic;

namespace partners;

public partial class ApplicationStatusHistory
{
    public int Id { get; set; }

    public int IdRequest { get; set; }

    public int IdApplicationStatus { get; set; }

    public DateOnly DateOfStatusChange { get; set; }

    public virtual ApplicationStatus IdApplicationStatusNavigation { get; set; } = null!;

    public virtual Request IdRequestNavigation { get; set; } = null!;
}
