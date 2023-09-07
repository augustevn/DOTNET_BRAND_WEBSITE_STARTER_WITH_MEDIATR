using NewsletterSubscribers.SharedSpa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var apiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? string.Empty;
builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(apiUrl)});

builder.Services.AddNewsletterSubscribersSharedSpa(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapFallbackToPage("/_Host");

app.Run();