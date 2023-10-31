using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.DataLoaders
{
    public class BrandDataLoader : BatchDataLoader<int, Brand>
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public BrandDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null,
            IEFUnitOfWork unitOfWork = null)
            : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<IReadOnlyDictionary<int, Brand>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            IEnumerable<Brand> instructors = await _unitOfWork.eFBrandsRepository.GetAllAsync();

            return instructors.ToDictionary(i => i.BrandId);
        }
    }
}
