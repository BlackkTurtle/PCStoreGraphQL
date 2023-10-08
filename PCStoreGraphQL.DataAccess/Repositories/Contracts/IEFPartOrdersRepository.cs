
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories.Contracts;

public interface IEFPartOrdersRepository : IEFGenericRepository<PartOrder>
{
    Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid);
}