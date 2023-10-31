using GraphQL.Types;
using PCStoreGraphQL.API.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class BrandQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public BrandQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            var results= await _unitOfWork.eFBrandsRepository.GetAllAsync();
            foreach (var result in results)
            {
                result.Products = (ICollection<Product>)await _unitOfWork.eFProductsRepository.GetProductsByBrandAsync(result.BrandId);
            }
            return results;
        }
    }
}
