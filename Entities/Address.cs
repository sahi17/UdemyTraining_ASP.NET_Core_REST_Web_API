using System.Collections.Specialized;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
