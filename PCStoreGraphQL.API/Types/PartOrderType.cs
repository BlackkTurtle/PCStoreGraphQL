using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class PartOrderType
{
    public int? PorderId { get; set; }

    public int Article { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }

}
