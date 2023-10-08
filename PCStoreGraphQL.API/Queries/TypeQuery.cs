using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class TypeQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public TypeQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Database.Models.Types>> GetAllTypesAsync()
        {
            try
            {
                var results = await _unitOfWork.EFTypesRepository.GetAllAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
