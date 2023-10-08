using System.Data.Entity;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFBrandsRepository : EFGenericRepository<Brand>, IEFBrandsRepository
{
    public EFBrandsRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Brand> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
