using Microsoft.AspNetCore.Identity;

namespace Golowinskiy_NewBostil.DAL.Entities
{
    public class User : IdentityUser
    {
        public double Coefficient { get; set; }
        public string DisplayName { get; set; }

        public string DisplayPassword { get; set; }
    }
}
