using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PartOrderQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public PartOrderQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderidAsync(int orderid)
        {
            try
            {
                var results = await _unitOfWork.eFPartOrdersRepository.GetAllPartOrdersByOrderIDAsync(orderid);
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<PartOrder> GetPartOrderByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.eFPartOrdersRepository.GetByIdAsync(id);
                if (result == null)
                {
                    throw new GraphQLException(new Error($"PartOrder із Id: {id}, не був знайдейний у базі даних"));
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
