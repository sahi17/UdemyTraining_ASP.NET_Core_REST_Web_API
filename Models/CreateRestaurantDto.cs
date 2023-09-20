namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Models
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
