using System;
using System.Collections.Generic;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Types;

public partial class BrandType
{
    public int? BrandId { get; set; }

    public string BrandName { get; set; } = null!;
}
