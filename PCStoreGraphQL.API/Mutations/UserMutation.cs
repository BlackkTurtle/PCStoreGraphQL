using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;
using PCStoreGraphQL.API.Types;

namespace PCStoreGraphQL.API.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UserMutation
    {
        private readonly IEFUnitOfWork _unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserMutation(IEFUnitOfWork unitOfWork,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<bool> LogInUserAsync([FromBody] UserType fullentity, string password)
        {
            try
            {
                var entity = await userManager.FindByNameAsync(fullentity.UserName);
                if (entity == null)
                {
                    throw new GraphQLException(new Error("User does not exist"));
                }
                var result = await signInManager.PasswordSignInAsync(entity, password, false, false);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<bool> LogOutAsync()
        {
            try
            {
                await signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
        public async Task<bool> PostUserAsync([FromBody] UserType fulluser, string password)
        {
            try
            {
                if (fulluser == null)
                {
                    throw new GraphQLException(new Error("Обєкт є null"));
                }
                var entity = new User()
                {
                    UserName = fulluser.UserName,
                    Email = fulluser.Email,
                    FirstName = fulluser.FirstName,
                    LastName = fulluser.LastName,
                    Father = fulluser.Father,
                    PhoneNumber = fulluser.PhoneNumber,
                };
                var result = userManager.CreateAsync(entity, password).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(entity, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
                    return true;
                }
                else
                {
                    throw new GraphQLException(new Error("Not Succeed!"));
                }
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<User> UpdateUserAsync([FromBody] UserType updatedentity)
        {
            try
            {
                if (updatedentity == null)
                {
                    throw new GraphQLException(new Error("Обєкт є null"));
                }

                var entity = await userManager.FindByNameAsync(updatedentity.UserName);
                if (entity == null)
                {
                    throw new GraphQLException(new Error($"username: {updatedentity.UserName} was not found in the database"));
                }
                entity.PhoneNumber = updatedentity.PhoneNumber;
                entity.Email = updatedentity.Email;
                entity.FirstName = updatedentity.FirstName;
                entity.LastName = updatedentity.LastName;
                entity.Father = updatedentity.Father;
                await _unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<bool> DeleteUserByIdAsync(string uname)
        {
            try
            {
                var entity = await userManager.FindByNameAsync(uname);
                if (entity == null)
                {
                    throw new GraphQLException(new Error($"Id: {uname}, не був знайдейний у базі даних"));
                }
                await userManager.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
