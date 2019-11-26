using Microsoft.AspNetCore.Identity;

namespace Golowinskiy_NewBostil.Entities
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }

        public string DisplayPassword { get; set; }
    }
}
