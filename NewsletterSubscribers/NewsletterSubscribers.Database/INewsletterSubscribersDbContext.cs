using Microsoft.EntityFrameworkCore;

namespace NewsletterSubscribers.Database;

public interface INewsletterSubscribersDbContext
{
    DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}