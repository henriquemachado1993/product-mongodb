using MongoDB.Bson;
using ProductRegistrationMongoDB.Domain.Entities;
using ProductRegistrationMongoDB.Domain.Interfaces;

namespace ProductRegistrationMongoDB.Service
{
    public class ProductService : IProductService
    {

        private readonly IBaseRepository<Product> _repository;

        public ProductService(IBaseRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            return await _repository.CreateAsync(product);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(new ObjectId(id));
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.FindAsync(_ => true);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(new ObjectId(id));
        }
    }
}
