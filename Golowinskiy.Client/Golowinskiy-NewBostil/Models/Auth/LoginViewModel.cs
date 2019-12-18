using System.ComponentModel.DataAnnotations;

namespace Golowinskiy_NewBostil.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
