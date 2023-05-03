using System;
using System.Collections.Generic;

namespace Repository_DL.DBModels;

public partial class UsersTbl
{
    public int Id { get; set; }

    public string? NameUser { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Web { get; set; }

    public virtual ICollection<ServiceToCraftsmanTbl> ServiceToCraftsmanTbls { get; set; } = new List<ServiceToCraftsmanTbl>();

    public virtual ServiceToCustomerTbl? ServiceToCustomerTbl { get; set; }
}
