using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using NewsletterSubscribers._Shared;
using NewsletterSubscribers._Shared.CreateNewsletterSubscriber;

namespace NewsletterSubscribers.SharedSpa;

public class NewsletterSubscribersHttpClient
{
    private readonly ILogger<NewsletterSubscribersHttpClient> _logger;
    private readonly HttpClient _http;
    private readonly NewsletterSubscribersState _state;
    public NewsletterSubscribersHttpClient(ILogger<NewsletterSubscribersHttpClient> logger, HttpClient http, NewsletterSubscribersState state)
    {
        _logger = logger;
        _http = http;
        _state = state;
    }

    public async Task InitNewsletterSubscribers(bool? force = false)
    {
        if (_state.NewsletterSubscribers?.Count() > 0 && force != true)
        {
            return;
        }

        _state.NewsletterSubscribers = await GetNewsletterSubscribers();
    }

    public async Task<IEnumerable<NewsletterSubscriberResponse>?> GetNewsletterSubscribers()
    {
        try
        {
            return await _http.GetFromJsonAsync<IEnumerable<NewsletterSubscriberResponse>>(ApiRoutes.NewsletterSubscribers);
        }
        catch (Exception e)
        {
            _logger.LogWarning("Could not get newsletter subscribers {@errorMessage}", e.Message);
            return null;
        }
    }
 
    public async Task<bool> CreateNewsletterSubscriber(CreateNewsletterSubscriberRequest request)
    {
        var response = await _http.PostAsJsonAsync(ApiRoutes.NewsletterSubscribers, request);
        return response.IsSuccessStatusCode;
    }
}