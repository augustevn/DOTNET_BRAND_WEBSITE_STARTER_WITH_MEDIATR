namespace NewsletterSubscribers.Database;

public abstract record AuditableEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
}

public record NewsletterSubscriber : AuditableEntity
{
    public string Email { get; set; }
    public bool IsSubscribed { get; set; }
    public bool IsEmailConfirmed { get; set; }
}