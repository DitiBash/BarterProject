using System;
using System.Collections.Generic;

namespace Repository_DL.DBModels;

public partial class ServiceToCustomerTbl
{
    public int Id { get; set; }

    public int? IdCustomer { get; set; }

    public int? IdServiceProvider { get; set; }

    public string? NumHours { get; set; }

    public int? PricePerHour { get; set; }

    public virtual UsersTbl IdNavigation { get; set; } = null!;
}
