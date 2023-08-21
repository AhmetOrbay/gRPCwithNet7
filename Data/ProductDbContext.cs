using Grpc.Core;
using gRPCwithDotnet.Data.Interfaces;
using gRPCwithDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace gRPCwithDotnet.Data
{
    public class ProductDbContext : IProductDbContext
    {
        private readonly gRPCDataContext _context;

        public ProductDbContext(gRPCDataContext context)
        {
            _context = context;
        }

        public async Task<CreateProductResponse> ProductCreate(Product request)
        {
            await _context.Products.AddAsync(request);
            await _context.SaveChangesAsync();
            return await Task.FromResult(new CreateProductResponse
            {
                Id = request.Id
            });
        }
        public async Task<List<Product>> ProductGetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> ProductGetSingle( int Id)
        {
            return await _context.Products.Where(x=>x.Id == Id)
                        .FirstOrDefaultAsync();
        }

        public async Task<Product> ProductUpdate(Product Product)
        {
            try
            {
                var aa = _context.Products.Update(Product);
                await _context.SaveChangesAsync();
                return aa.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Product> ProductDelete(int Id)
        {
            var model = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            
            if(model is not null)
            {
                model.IsDelete = true;
                return await ProductUpdate(model);
            }
            throw new ArgumentNullException();
        }
    }
}
