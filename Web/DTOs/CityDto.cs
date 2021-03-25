using System.ComponentModel.DataAnnotations;

namespace Web.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} The field must have a value greater  than 1 ")]
        public int PostCode { get; set; }
        public int CountryId { get; set; }

    }
}