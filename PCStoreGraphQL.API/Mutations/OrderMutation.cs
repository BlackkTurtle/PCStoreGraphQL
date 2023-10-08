using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.API.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrderMutation
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public OrderMutation(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> PostOrderAsync([FromBody] OrderType fullorder)
        {
            try
            {
                if (fullorder == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }
                var comment = new Order()
                {
                    OrderDate = DateTime.Now,
                    Adress = fullorder.Adress,
                    UserId = fullorder.UserId,
                    StatusId = fullorder.StatusId
                };
                await _unitOfWork.eFOrdersRepository.AddAsync(comment);
                await _unitOfWork.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<Order> UpdateOrderAsync(int id, [FromBody] OrderType updatedOrder)
        {
            try
            {
                if (updatedOrder == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }

                var OrderEntity = await _unitOfWork.eFOrdersRepository.GetByIdAsync(id);
                if (OrderEntity == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }

                // Update only the specific properties of the comment entity
                OrderEntity.StatusId = updatedOrder.StatusId;
                OrderEntity.Adress = updatedOrder.Adress;
                OrderEntity.UserId = updatedOrder.UserId;

                await _unitOfWork.SaveChangesAsync();
                return OrderEntity;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork.eFOrdersRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }

                await _unitOfWork.eFOrdersRepository.DeleteAsync(event_entity);
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
