using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Golowinskiy.DAL.Entities;

namespace Golowinskiy.DAL.Context
{
    public class GolowinskiyDBContext : IdentityDbContext<User>
    {
        public GolowinskiyDBContext(DbContextOptions<GolowinskiyDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
