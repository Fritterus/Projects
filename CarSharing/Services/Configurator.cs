using CarSharing.Entities;
using CarSharing.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarSharing.Services
{
    public static class Configurator
    {   
        public static void ConfiguratorConfig(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DbContext, Context>();
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 4;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            }).AddEntityFrameworkStores<Context>();
            services.AddScoped<IRepository<Car>, Repository<Car>>();
            services.AddScoped<IRepository<CarModel>, Repository<CarModel>>();
            services.AddScoped<IRepository<Make>, Repository<Make>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<Statement>, Repository<Statement>>();
        }
    }
}
