using System;
using System.Collections.Generic;

namespace Repository_DL.DBModels;

public partial class ServiceToCraftsmanTbl
{
    public int IdCraftsman { get; set; }

    public int IdTypeService { get; set; }

    public int? PricePerHour { get; set; }

    public virtual UsersTbl IdCraftsmanNavigation { get; set; } = null!;

    public virtual ServiceTypeTbl IdTypeServiceNavigation { get; set; } = null!;
}
