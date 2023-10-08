using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class StatusType
{
    public int? StatusId { get; set; }

    public string StatusName { get; set; } = null!;

}
