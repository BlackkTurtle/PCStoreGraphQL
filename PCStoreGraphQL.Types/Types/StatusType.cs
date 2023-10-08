using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class StatusType:ObjectGraphType<Status>
    {
        public StatusType()
        {
            Field(x => x.StatusId);
            Field(x => x.StatusName);
        }
    }
}
