using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class PartOrderType:ObjectGraphType<PartOrder>
    {
        public PartOrderType()
        {
            Field(x => x.PorderId);
            Field(x => x.Article);
            Field(x => x.OrderId);
            Field(x => x.Quantity);
            Field(x=> x.Price);
        }
    }
}
