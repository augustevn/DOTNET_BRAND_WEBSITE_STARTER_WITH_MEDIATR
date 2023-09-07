using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NewsletterSubscribers._Shared;
using NewsletterSubscribers._Shared.CreateNewsletterSubscriber;
using NewsletterSubscribers.Features.CreateNewsletterSubscriber;
using NewsletterSubscribers.Features.GetNewsletterSubscribers;

namespace NewsletterSubscribers.Api;

public static class Extensions
{
    public static void MapNewsletterSubscriberEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var routeGroup = routeBuilder.MapGroup(ApiRoutes.NewsletterSubscribers);

        routeGroup.MapGet("/", async (ISender mediator) =>
        {
            var subs = await mediator.Send(new GetNewsletterSubscribersQuery());
            return Results.Ok(subs);
        });
        
        routeGroup.MapPost("/", async (CreateNewsletterSubscriberRequest request, ISender mediator) =>
        {
            await mediator.Send(new CreateNewsletterSubscriberCommand { Email = request.Email });
            return Results.NoContent();
        });
    }
}