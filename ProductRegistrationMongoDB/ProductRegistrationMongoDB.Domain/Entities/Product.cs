using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductRegistrationMongoDB.Domain.Interfaces;

namespace ProductRegistrationMongoDB.Domain.Entities
{
    public class Product : IId
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public List<string>? Categories { get; set; }

    }
}
