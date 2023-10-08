using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFTypesRepository : EFGenericRepository<Types>, IEFTypesRepository
{
    public EFTypesRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }
    public override Task<Types> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
