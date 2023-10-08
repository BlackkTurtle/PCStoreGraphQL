using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class BrandType:ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Field(x => x.BrandId);
            Field(x => x.BrandName);
        }
    }
}
