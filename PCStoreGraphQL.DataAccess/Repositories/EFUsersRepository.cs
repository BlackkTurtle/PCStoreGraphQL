using Microsoft.EntityFrameworkCore;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFUsersRepository : EFGenericRepository<User>, IEFUsersRepository
{
    public EFUsersRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<User> GetUserByEmailAsync(string Email)
    {
        return await databaseContext.Users.SingleOrDefaultAsync(v => v.Email == Email)
            ?? throw new Exception($"Couldn't retrieve entities Users");
    }

    public async Task<User> GetUserByPhoneAsync(string Phone)
    {
        return await databaseContext.Users.SingleOrDefaultAsync(v => v.PhoneNumber == Phone)
            ?? throw new Exception($"Couldn't retrieve entities Users");
    }

    public override Task<User> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}

