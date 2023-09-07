using Microsoft.EntityFrameworkCore;

namespace NewsletterSubscribers.Database;

public class NewsletterSubscribersDbContext : DbContext, INewsletterSubscribersDbContext
{
    public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
    
    public NewsletterSubscribersDbContext(DbContextOptions<NewsletterSubscribersDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsletterSubscriber>()
            .HasIndex(sub => sub.Email)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
}