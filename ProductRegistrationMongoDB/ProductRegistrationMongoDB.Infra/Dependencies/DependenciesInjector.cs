﻿using Microsoft.Extensions.DependencyInjection;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Infra.Context;
using ProductRegistrationMongoDB.Infra.Repositories;
using ProductRegistrationMongoDB.Service;
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
        }
    }
}