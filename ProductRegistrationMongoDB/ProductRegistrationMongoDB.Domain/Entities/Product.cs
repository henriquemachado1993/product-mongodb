using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductRegistrationMongoDB.Domain.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ObjectId CategoryId{ get; set; }

    }
}
