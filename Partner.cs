using System;
using System.Collections.Generic;

namespace partners;

public partial class Partner
{
    public int Id { get; set; }

    public int IdTypeOfPartner { get; set; }

    public string CompanyName { get; set; } = null!;

    public List<string>? Inn { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public List<string>? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public DateOnly DateOfRegistrationPartner { get; set; }

    public virtual TypeOfPartner IdTypeOfPartnerNavigation { get; set; } = null!;

    public virtual ICollection<ImplementationHistory> ImplementationHistories { get; set; } = new List<ImplementationHistory>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
