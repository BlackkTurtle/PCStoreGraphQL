using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class TypesType:ObjectGraphType<Database.Models.Types>
    {
        public TypesType()
        {
            Field(x => x.Id);
            Field(x => x.TypeName);
        }
    }
}
