using System.ComponentModel.DataAnnotations;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Models
{
    public class UpdateRestaurantDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
    }
}
