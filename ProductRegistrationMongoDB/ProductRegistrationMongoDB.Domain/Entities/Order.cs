using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductRegistrationMongoDB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Domain.Entities
{
    public class Order : IBaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
    }
}
