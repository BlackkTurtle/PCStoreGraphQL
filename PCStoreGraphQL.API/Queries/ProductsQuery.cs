using Microsoft.AspNetCore.Mvc;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.API.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProductsQuery
    {
        private readonly IEFUnitOfWork _unitOfWork;

        public ProductsQuery(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                var results = await _unitOfWork.eFProductsRepository.GetAllAsync();
                foreach (var product in results)
                {
                    product.Brand= await _unitOfWork.eFBrandsRepository.GetByIdAsync(product.BrandId);
                    product.TypeNavigation = await _unitOfWork.EFTypesRepository.GetByIdAsync(product.Type);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
        public async Task<IEnumerable<Product>> GetProductsByBrandIDAsync(int id)
        {
            try
            {
                var results = await _unitOfWork.eFProductsRepository.GetProductsByBrandAsync(id);
                foreach (var product in results)
                {
                    product.Brand = await _unitOfWork.eFBrandsRepository.GetByIdAsync(product.BrandId);
                    product.TypeNavigation = await _unitOfWork.EFTypesRepository.GetByIdAsync(product.Type);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
        [HttpGet("TypeID")]
        public async Task<IEnumerable<Product>> GetProductsByTypeIDAsync(int id)
        {
            try
            {
                var results = await _unitOfWork.eFProductsRepository.GetProductsByTypeAsync(id);
                foreach (var product in results)
                {
                    product.Brand = await _unitOfWork.eFBrandsRepository.GetByIdAsync(product.BrandId);
                    product.TypeNavigation = await _unitOfWork.EFTypesRepository.GetByIdAsync(product.Type);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
        [HttpGet("NameLike")]
        public async Task<IEnumerable<Product>> GetProductsByNAMELikeAsync(string namelike)
        {
            try
            {
                var results = await _unitOfWork.eFProductsRepository.GetProductsByNameLikeAsync(namelike);
                foreach (var product in results)
                {
                    product.Brand = await _unitOfWork.eFBrandsRepository.GetByIdAsync(product.BrandId);
                    product.TypeNavigation = await _unitOfWork.EFTypesRepository.GetByIdAsync(product.Type);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw new GraphQLException(new Error(ex.Message));
            }
        }
    }
}
