using GraphQL.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class OrderQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public OrderQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userid)
        {
            try
            {
                var results = await _unitOfWork.eFOrdersRepository.GetAllOrdersByUserIDAsync(userid);
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
        public async Task<Order> GetOrdersById(int id)
        {
            try
            {
                var result = await _unitOfWork.eFOrdersRepository.GetByIdAsync(id);
                if (result == null)
                {
                    throw new GraphQLException(new Error("Order do not exist!"));
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
