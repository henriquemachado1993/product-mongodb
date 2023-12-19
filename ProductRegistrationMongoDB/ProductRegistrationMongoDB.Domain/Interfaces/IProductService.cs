using ProductRegistrationMongoDB.Domain.Entities;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();
        public Task CreateAsync(Product product);
    }
}
