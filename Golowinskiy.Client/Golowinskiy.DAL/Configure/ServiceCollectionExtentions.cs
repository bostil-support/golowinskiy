using System;
using Golowinskiy.DAL.Context;
using Golowinskiy.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Golowinskiy.DAL.Configure
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDALServicies(this IServiceCollection services, string connection, IConfiguration configuration)
        {
            services.AddDbContext<GolowinskiyDBContext>(options =>
                options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<GolowinskiyDBContext>();

            return services;
        }
    }
}
