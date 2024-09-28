using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infrastructure.Persistence;
using Restaurant.Infrastructure.Seeders;


namespace Restaurant.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectString = configuration.GetConnectionString("RestaurantDb");
            services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectString));
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        }

    }
}
