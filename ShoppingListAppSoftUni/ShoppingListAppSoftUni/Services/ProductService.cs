using Microsoft.EntityFrameworkCore;
using ShoppingListAppSoftUni.Contracts;
using ShoppingListAppSoftUni.Data;
using ShoppingListAppSoftUni.Data.Models;
using ShoppingListAppSoftUni.Models;

namespace ShoppingListAppSoftUni.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _context;

        public ProductService(ShoppingListDbContext context)
        {
            _context = context;
        }


        public async Task AddProductAsync(ProductViewModel model)
        {
            Product newProduct = new Product()
            {
                Name = model.Name
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            _context.Products.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            var model = new ProductViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return model;
        }

        public async Task UpdateProductAsync(ProductViewModel model)
        {
            var entity = await _context.Products.FindAsync(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            entity.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
