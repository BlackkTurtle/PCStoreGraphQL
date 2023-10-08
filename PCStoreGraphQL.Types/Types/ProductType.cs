using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.Types.Types
{
    public class ProductType:ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Article);
            Field(x => x.Name);
            Field(x => x.Picture);
            Field(x => x.Type);
            Field(x => x.Price);
            Field(x => x.ProductInfo);
            Field(x => x.BrandId);
            Field(x=>x.Availability);
        }
    }
}
