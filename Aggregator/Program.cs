using Aggregator.Data;
using Aggregator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add SQLite + Identity
builder.Services.AddDbContext<AggregatorContext>(options =>
    options.UseSqlite("Data Source=aggregator.db"));

// Add Identity with default token providers
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AggregatorContext>()
    .AddDefaultTokenProviders();

// Enable controllers
builder.Services.AddControllers();

// Enable Swagger for testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS for frontend access
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Swagger in dev only
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

// Enable authentication + authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
