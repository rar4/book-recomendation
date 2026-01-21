
using bookrec;
using bookrec.Components;
using bookrec.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<BookContext>();
builder.Services.AddScoped<Utils>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


// app.MapPost("api/rate", );
app.MapGet("/api/feed", UserInteraction.FeedEndpoint);
app.MapPost("/api/rate", UserInteraction.RateEndpoint);
app.MapGet("/api/dberror", UserInteraction.DbErrorEndpoint);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();




app.Run();
