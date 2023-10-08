using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class UserQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public UserQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> GetUserByPhoneAsync(string Phone)
        {
            try
            {
                var results = await _unitOfWork.eFUsersRepository.GetUserByPhoneAsync(Phone);
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            try
            {
                var results = await _unitOfWork.eFUsersRepository.GetUserByEmailAsync(Email);
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.eFUsersRepository.GetByIdAsync(id);
                if (result == null)
                {
                    throw new GraphQLException(new Error($"User із Id: {id}, не був знайдейний у базі даних"));
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
