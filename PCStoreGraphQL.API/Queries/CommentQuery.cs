using GraphQL.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class CommentQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public CommentQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Comment>> GetCommentById(int article)
        {
            return await _unitOfWork.eFCommentsRepository.GetAllCommentsByArticleAsync(article); ;
        }
    }
}
