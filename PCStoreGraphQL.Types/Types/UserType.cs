using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class UserType:ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Email);
            Field(x => x.Father);
            Field(x=>x.PhoneNumber);
            Field(x => x.UserName);
        }
    }
}
