

using System.Data.Entity;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFStatusesRepository : EFGenericRepository<Status>, IEFStatusesRepository
{
    public EFStatusesRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override async Task<Status> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
