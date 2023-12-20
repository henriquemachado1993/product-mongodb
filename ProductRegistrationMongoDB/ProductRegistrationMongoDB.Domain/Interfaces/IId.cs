using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IId
    {
        ObjectId Id { get; set; }
    }
}
