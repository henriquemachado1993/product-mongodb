using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductRegistrationMongoDB.Domain.Interfaces;

namespace ProductRegistrationMongoDB.Domain.Entities
{
    public class Category : IBaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
