using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsletterSubscribers._Shared;
using NewsletterSubscribers.Database;

namespace NewsletterSubscribers.Features.GetNewsletterSubscribers;

public record GetNewsletterSubscribersQuery : IRequest<IEnumerable<NewsletterSubscriberResponse>>
{
}

public class GetNewsletterSubscribersQueryHandler : IRequestHandler<GetNewsletterSubscribersQuery, IEnumerable<NewsletterSubscriberResponse>>
{
    private readonly INewsletterSubscribersDbContext _dbContext;
    public GetNewsletterSubscribersQueryHandler(INewsletterSubscribersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<NewsletterSubscriberResponse>> Handle(GetNewsletterSubscribersQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.NewsletterSubscribers
            .OrderBy(sub => sub.Email)
            .ProjectToType<NewsletterSubscriberResponse>()
            .ToListAsync(cancellationToken);
    }
}