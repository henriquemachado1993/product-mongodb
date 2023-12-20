using ProductRegistrationMongoDB.Domain.Entities;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(string id);
        public Task<Product> CreateAsync(Product product);
        public Task<Product> UpdateAsync(Product product);
        public Task DeleteAsync(string id);
    }
}
