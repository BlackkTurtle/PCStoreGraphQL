using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class ProductType
{
    public int? Article { get; set; }

    public string Name { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public int Type { get; set; }

    public float Price { get; set; }

    public string? ProductInfo { get; set; }

    public int BrandId { get; set; }

    public bool Availability { get; set; }

}
