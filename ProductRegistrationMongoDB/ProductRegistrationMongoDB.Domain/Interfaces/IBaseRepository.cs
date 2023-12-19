using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IBaseRepository<T>

    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> filterExpression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(ObjectId id);
    }
}
