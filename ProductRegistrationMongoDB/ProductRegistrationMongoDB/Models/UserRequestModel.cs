namespace ProductRegistrationMongoDB.Models
{
    public class UserRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
    }

    public class AddressModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
