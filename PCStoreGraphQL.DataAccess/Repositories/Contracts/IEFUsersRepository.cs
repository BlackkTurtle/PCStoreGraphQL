
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories.Contracts;

public interface IEFUsersRepository : IEFGenericRepository<User>
{
    Task<User> GetUserByEmailAsync(string Email);
    Task<User> GetUserByPhoneAsync(string Email);
}