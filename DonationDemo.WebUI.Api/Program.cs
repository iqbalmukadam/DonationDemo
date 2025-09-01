using DonationDemo.Application.Services;
using DonationDemo.Domain.Entities;
using DonationDemo.Domain.Interfaces;
using DonationDemo.Infrastructure.Data;
using DonationDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DonationDbContext>(options =>
    options.UseInMemoryDatabase("DonationDb"));

builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<DonationService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DonationDbContext>();
    dbContext.Database.EnsureCreated(); // ensures seeding runs
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/donations", async (DonationService service) =>
{
    return Results.Ok(await service.GetDonationsAsync());
});

app.MapGet("/donations/{id:int}", async (int id, DonationService service) =>
{
    var donation = await service.GetDonationByIdAsync(id);
    return donation is null ? Results.NotFound() : Results.Ok(donation);
});

app.MapPost("/donations", async (Donation donation, DonationService service) =>
{
    await service.AddDonationAsync(donation);
    return Results.Created($"/donations/{donation.Id}", donation);
});

app.MapPut("/donations/{id:int}", async (int id, Donation donation, DonationService service) =>
{
    var existingDonation = await service.GetDonationByIdAsync(id);
    if (existingDonation is null) return Results.NotFound();

    donation.Id = id;
    await service.UpdateDonationAsync(donation);
    return Results.NoContent();
});

app.MapDelete("/donations/{id:int}", async (int id, DonationService service) =>
{
    await service.DeleteDonationAsync(id);
    return Results.NoContent();
});






app.Run();


