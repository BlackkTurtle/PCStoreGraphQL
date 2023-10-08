using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class CommentType:ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.CommentId);
            Field(x => x.Article);
            Field(x => x.Stars);
            Field(x => x.CommentDate);
            Field(x=>x.UserId);
            Field(x => x.Comment1);
        }
    }
}
