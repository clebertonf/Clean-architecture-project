using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _applicationDbContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _applicationDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateeAsync(Product product)
        {
            _applicationDbContext.Products.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}
