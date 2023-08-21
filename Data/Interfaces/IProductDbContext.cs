using gRPCwithDotnet.Models;

namespace gRPCwithDotnet.Data.Interfaces
{
    public interface IProductDbContext
    {
        Task<CreateProductResponse> ProductCreate(Product request);
        Task<List<Product>> ProductGetAll();

        Task<Product> ProductGetSingle(int Id);
        Task<Product> ProductUpdate(Product Product);

        Task<Product> ProductDelete(int Id);
    }
}
