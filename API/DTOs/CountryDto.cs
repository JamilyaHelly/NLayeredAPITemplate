using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
    }
}