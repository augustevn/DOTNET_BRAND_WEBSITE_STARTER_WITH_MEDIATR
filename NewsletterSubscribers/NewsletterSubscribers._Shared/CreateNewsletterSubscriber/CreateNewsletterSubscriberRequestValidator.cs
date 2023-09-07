using FluentValidation;

namespace NewsletterSubscribers._Shared.CreateNewsletterSubscriber;

public class CreateNewsletterSubscriberRequestValidator : AbstractValidator<CreateNewsletterSubscriberRequest>
{
    public CreateNewsletterSubscriberRequestValidator()
    {
        RuleFor(request => request.Email)
            .EmailAddress()
            .WithMessage("Invalid email address");
    }
}