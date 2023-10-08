using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.API.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class CommentMutation
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public CommentMutation(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommentType> PostCommentAsync([FromBody] CommentType fullcomment)
        {
            try
            {
                if (fullcomment == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }
                var comment = new Comment()
                {
                    Article = fullcomment.Article,
                    Stars = fullcomment.Stars,
                    UserId = fullcomment.UserId,
                    CommentDate = DateTime.Now,
                    Comment1 = fullcomment.Comment1
                };
                await _unitOfWork.eFCommentsRepository.AddAsync(comment);
                await _unitOfWork.SaveChangesAsync();
                return fullcomment;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<CommentType> UpdateCommentAsync(int id, [FromBody] CommentType updatedComment)
        {
            try
            {
                if (updatedComment == null)
                {
                    throw new GraphQLException(new Error("Comment object is null"));
                }

                var commentEntity = await _unitOfWork.eFCommentsRepository.GetByIdAsync(id);
                if (commentEntity == null)
                {
                    throw new GraphQLException(new Error("is null"));
                }

                commentEntity.Article = updatedComment.Article;
                commentEntity.Stars = updatedComment.Stars;
                commentEntity.UserId = updatedComment.UserId;
                commentEntity.Comment1 = updatedComment.Comment1;

                await _unitOfWork.SaveChangesAsync();
                return updatedComment;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }


        public async Task<bool> DeleteCommentByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork.eFCommentsRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    throw new GraphQLException(new Error("is null"));
                }

                await _unitOfWork.eFCommentsRepository.DeleteAsync(event_entity);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
