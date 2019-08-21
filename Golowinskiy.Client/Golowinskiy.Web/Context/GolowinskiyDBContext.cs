using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Golowinskiy.Web.Entities;

namespace Golowinskiy.Web.Context
{
    public class GolowinskiyDBContext : IdentityDbContext<User>
    {
        public GolowinskiyDBContext(DbContextOptions<GolowinskiyDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
