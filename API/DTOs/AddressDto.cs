using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string HomeNumber { get; set; }
        public string Description { get; set; }
         public int CityId { get; set; }

    }
}