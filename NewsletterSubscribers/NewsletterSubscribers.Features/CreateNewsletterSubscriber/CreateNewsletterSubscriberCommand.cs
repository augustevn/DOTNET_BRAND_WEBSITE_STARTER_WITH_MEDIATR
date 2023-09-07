using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsletterSubscribers._Shared.CreateNewsletterSubscriber;
using NewsletterSubscribers.Database;

namespace NewsletterSubscribers.Features.CreateNewsletterSubscriber;

public record CreateNewsletterSubscriberCommand : CreateNewsletterSubscriberRequest, IRequest;

public class CreateNewsletterSubscriberCommandHandler : IRequestHandler<CreateNewsletterSubscriberCommand>
{
    private readonly INewsletterSubscribersDbContext _dbContext;
    private readonly ILogger<CreateNewsletterSubscriberCommand> _logger;
    public CreateNewsletterSubscriberCommandHandler(INewsletterSubscribersDbContext dbContext, ILogger<CreateNewsletterSubscriberCommand> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task Handle(CreateNewsletterSubscriberCommand request, CancellationToken cancellationToken)
    {
        var sanitizedEmail = request.Email.ToLower().Trim();
    
        var existingSub = await _dbContext.NewsletterSubscribers
            .FirstOrDefaultAsync(sub => sub.Email == sanitizedEmail, cancellationToken);

        if (existingSub != null)
        {
            _logger.LogWarning("Email subscriber already exists");
            return;
        }
    
        var newSub = new NewsletterSubscriber
        {
            Email = sanitizedEmail,
            IsSubscribed = true
        };
    
        await _dbContext.NewsletterSubscribers.AddAsync(newSub, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}