using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductRegistrationMongoDB.Domain.Entities
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
