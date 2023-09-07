using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewsletterSubscribers.SharedSpa;

public static class Extensions
{
    public static void AddNewsletterSubscribersSharedSpa(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<NewsletterSubscribersHttpClient>();
        services.AddScoped<NewsletterSubscribersState>();
    }
}