using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class TypesType
{
    public int? Id { get; set; }

    public string TypeName { get; set; } = null!;

}
