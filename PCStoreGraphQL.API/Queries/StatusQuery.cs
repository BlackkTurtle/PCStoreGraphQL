using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class StatusQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public StatusQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            try
            {
                var results = await _unitOfWork.eFStatusesRepository.GetAllAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
