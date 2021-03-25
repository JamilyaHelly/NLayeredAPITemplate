using System.ComponentModel.DataAnnotations;

namespace Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
    }
}