using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class OrderType
{
    public int? OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Adress { get; set; } = null!;

    public int UserId { get; set; }

    public int StatusId { get; set; }

}
