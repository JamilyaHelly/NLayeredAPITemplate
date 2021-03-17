using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "{0} field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage= "{0} field is required")]
        public string Surname { get; set; }
        public int IdentityNumber { get; set; }

        [Required(ErrorMessage= "{0} field is required")]
        public string TelefonNumber { get; set; }
    }
}