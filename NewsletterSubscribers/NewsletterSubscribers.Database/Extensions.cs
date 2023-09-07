using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewsletterSubscribers.Database;

public static class Extensions
{
    public static void AddNewsletterSubscribersDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NewsletterSubscribersDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(NewsletterSubscribersDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        
        services.AddScoped<INewsletterSubscribersDbContext, NewsletterSubscribersDbContext>();
    }
}