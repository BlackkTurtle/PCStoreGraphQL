using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.API.Types;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class PartOrderMutation
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public PartOrderMutation(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<PartOrder> PostPartOrderAsync([FromBody] PartOrderType fullpartorder)
        {
            try
            {
                if (fullpartorder == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }
                var partorder = new PartOrder()
                {
                    Article = fullpartorder.Article,
                    OrderId = fullpartorder.OrderId,
                    Quantity = fullpartorder.Quantity,
                    Price = fullpartorder.Price
                };
                await _unitOfWork.eFPartOrdersRepository.AddAsync(partorder);
                await _unitOfWork.SaveChangesAsync();
                return partorder;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        //POST: api/events/id
        [HttpPut("{id}")]
        public async Task<PartOrder> UpdatePartOrderAsync(int id, [FromBody] PartOrderType updatedPartOrder)
        {
            try
            {
                if (updatedPartOrder == null)
                {
                    throw new GraphQLException(new Error("Обєкт comment є null"));
                }

                var PartOrderEntity = await _unitOfWork.eFPartOrdersRepository.GetByIdAsync(id);
                if (PartOrderEntity == null)
                {
                    throw new GraphQLException(new Error($"PartOrder with ID: {id} was not found in the database"));
                }
                PartOrderEntity.Article = updatedPartOrder.Article;
                PartOrderEntity.OrderId = updatedPartOrder.OrderId;
                PartOrderEntity.Quantity = updatedPartOrder.Quantity;
                PartOrderEntity.Price = updatedPartOrder.Price;

                await _unitOfWork.SaveChangesAsync();
                return PartOrderEntity;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }

        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<bool> DeletePartOrderByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork.eFPartOrdersRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    throw new GraphQLException(new Error($"PartOrder with ID: {id} was not found in the database"));
                }

                await _unitOfWork.eFPartOrdersRepository.DeleteAsync(event_entity);
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
