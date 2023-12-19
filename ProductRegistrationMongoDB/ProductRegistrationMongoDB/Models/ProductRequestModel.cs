namespace ProductRegistrationMongoDB.Models
{
    public class ProductRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}
