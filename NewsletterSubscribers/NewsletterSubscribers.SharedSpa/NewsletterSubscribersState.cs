using NewsletterSubscribers._Shared;

namespace NewsletterSubscribers.SharedSpa;

public class NewsletterSubscribersState
{
    public IEnumerable<NewsletterSubscriberResponse>? NewsletterSubscribers { get; set; }
}