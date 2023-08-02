using MudBlazor.Services;
using Polly;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<SpaceTraders.Client.Configuration>();
builder.Services.AddScoped<Space.Models.SpaceApplication>();
builder.Services.AddMudServices();

SpaceTraders.Client.RetryConfiguration.AsyncRetryPolicy =
    Policy<RestResponse>
        .HandleResult(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        .WaitAndRetryAsync(4, i => TimeSpan.FromSeconds(i - 1 + (Random.Shared.NextDouble() * 2)));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
