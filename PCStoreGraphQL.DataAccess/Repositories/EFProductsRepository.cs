﻿using Microsoft.EntityFrameworkCore;
using PCStoreGraphQL.DataAccess.Exceptions;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

namespace PCStoreGraphQL.DataAccess.Repositories;

public class EFProductsRepository : EFGenericRepository<Product>, IEFProductsRepository
{
    public EFProductsRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }
    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID)
    {
        return await databaseContext.Products.Where(v => v.BrandId == BrandID).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }

    public async Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName)
    {
        return await databaseContext.Products.Where(v => v.Name.Contains(LikeName)).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID)
    {
        return await databaseContext.Products.Where(v => v.Type == TypeID).ToListAsync()
            ?? throw new Exception($"Couldn't retrieve entities Products");
    }
    public override async Task<Product> GetCompleteEntityAsync(int id)
    {
        var my_event = await table.Include(ev => ev.Type)
                                 .Include(ev => ev.BrandId)
                                 .SingleOrDefaultAsync(ev => ev.Article == id);
        return my_event ?? throw new EntityNotFoundException("NOT FOUND");
    }
}
