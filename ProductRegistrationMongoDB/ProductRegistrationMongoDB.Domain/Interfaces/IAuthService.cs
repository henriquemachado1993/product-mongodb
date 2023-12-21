using ProductRegistrationMongoDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}
