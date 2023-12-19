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

        public async Task CreateAsync(Product product)
        {
            await _repository.CreateAsync(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.FindAsync(_ => true);
        }
    }
}
