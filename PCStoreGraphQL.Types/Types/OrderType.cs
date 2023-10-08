using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class OrderType:ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.OrderId);
            Field(x => x.OrderDate);
            Field(x => x.Adress);
            Field(x=>x.UserId);
            Field(x => x.StatusId);
        }
    }
}
