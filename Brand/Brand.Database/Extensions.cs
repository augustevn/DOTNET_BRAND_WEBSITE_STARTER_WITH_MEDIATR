using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brand.Database;

public static class Extensions
{
    public static void AddBrandDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BrandDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BrandDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddScoped<IBrandDbContext, BrandDbContext>();
    }
}