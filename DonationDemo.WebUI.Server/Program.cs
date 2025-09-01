using DonationDemo.Application;
using DonationDemo.Application.Services;
using DonationDemo.Domain.Interfaces;
using DonationDemo.Infrastructure;
using DonationDemo.Infrastructure.Data;
using DonationDemo.Infrastructure.Repositories;
using DonationDemo.WebUI.Server.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure EF InMemory DB
builder.Services.AddDbContext<DonationDbContext>(options =>
    options.UseInMemoryDatabase("DonationDb"));

// Dependency Injection
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<DonationService>(); 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DonationDbContext>();
    dbContext.Database.EnsureCreated(); // ensures seeding runs
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
