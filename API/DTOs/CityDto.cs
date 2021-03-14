using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PostCode { get; set; }
        public int CountryId { get; set; }
       
    }
}