using System;
using System.Collections.Generic;

namespace Repository_DL.DBModels;

public partial class ServiceTypeTbl
{
    public int IdService { get; set; }

    public string? NameService { get; set; }

    public virtual ICollection<ServiceToCraftsmanTbl> ServiceToCraftsmanTbls { get; set; } = new List<ServiceToCraftsmanTbl>();
}
