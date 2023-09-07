namespace NewsletterSubscribers._Shared;

public record NewsletterSubscriberResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool IsSubscribed { get; set; }
    public bool IsEmailConfirmed { get; set; }
}