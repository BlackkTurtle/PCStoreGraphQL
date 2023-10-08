

using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories.Contracts;

public interface IEFOrdersRepository : IEFGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(int userid);
}