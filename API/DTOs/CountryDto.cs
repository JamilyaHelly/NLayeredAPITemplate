using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}