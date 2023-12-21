using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Infra.Auth;
using ProductRegistrationMongoDB.Infra.Context;
using ProductRegistrationMongoDB.Infra.Repositories;
using ProductRegistrationMongoDB.Service;
using ProductRegistrationMongoDB.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Infra.Dependencies
{
    public class DependenciesInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            // Context
            svcCollection.AddScoped<MongoDBContext>();
            
            // Repositories
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Services
            svcCollection.AddScoped<IProductService, ProductService>();
            svcCollection.AddScoped<IOrderService, OrderService>();
            svcCollection.AddScoped<IUserService, UserService>();

            // Auth
            svcCollection.AddScoped<IAuthService, AuthService>();
            svcCollection.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        }
    }
}
