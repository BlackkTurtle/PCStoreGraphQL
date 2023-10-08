using Microsoft.EntityFrameworkCore;
using PCStoreGraphQL.DataAccess.Exceptions;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFPartOrdersRepository : EFGenericRepository<PartOrder>, IEFPartOrdersRepository
{
    public EFPartOrdersRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }
    public async Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid)
    {
        return await databaseContext.PartOrders.Where(v => v.OrderId == orderid).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities PartOrders");
    }
    public override async Task<PartOrder> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.Article)
                                 .Include(ev => ev.OrderId)
                                 .SingleOrDefaultAsync(ev => ev.PorderId == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
}
