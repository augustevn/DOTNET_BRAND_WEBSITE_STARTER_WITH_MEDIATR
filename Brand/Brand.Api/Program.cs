using Brand.Database;
using NewsletterSubscribers.Api;
using NewsletterSubscribers.Database;
using NewsletterSubscribers.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBrandDbContext(builder.Configuration);

builder.Services.AddNewsletterSubscribersDbContext(builder.Configuration);
builder.Services.AddNewsletterSubscribersFeatures(builder.Configuration);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseCors(options =>
        options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
}

app.MapGet("/", () => "Hello World!");

app.MapNewsletterSubscriberEndpoints();

app.Run();