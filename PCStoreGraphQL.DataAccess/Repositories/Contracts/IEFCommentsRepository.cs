

using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories.Contracts;

public interface IEFCommentsRepository : IEFGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article);
}