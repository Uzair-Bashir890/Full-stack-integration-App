using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Memory;
using ServerApp.Models;

// Generated and optimized using GitHub Copilot
// This file demonstrates the integration of Minimal API patterns with caching and proper error handling

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Memory Cache for performance optimization
builder.Services.AddMemoryCache();

// Add response compression for better performance
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

// Configure JSON serialization
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.WriteIndented = true;
});

// Add CORS services
builder.Services.AddCors();

var app = builder.Build();

// Configure CORS policy
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Endpoint optimized with caching and proper error handling
app.MapGet("/api/productlist", async (IMemoryCache cache, ILogger<Program> logger) =>
{
    try
    {
        // Try to get products from cache first
        const string cacheKey = "ProductList";
        if (cache.TryGetValue(cacheKey, out ApiResponse? cachedResponse))
        {
            logger.LogInformation("Returning products from cache");
            return Results.Ok(cachedResponse);
        }

        logger.LogInformation("Fetching products from data source");
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200.50M,
                Stock = 25,
                Category = new Category { Id = 101, Name = "Electronics" }
            },
            new Product
            {
                Id = 2,
                Name = "Headphones",
                Price = 50.00M,
                Stock = 100,
                Category = new Category { Id = 102, Name = "Accessories" }
            },
            new Product
            {
                Id = 3,
                Name = "Gaming Mouse",
                Price = 79.99M,
                Stock = 50,
                Category = new Category { Id = 102, Name = "Accessories" }
            }
        };

        var response = new ApiResponse
        {
            Status = "success",
            Timestamp = DateTime.UtcNow,
            Data = products,
            Count = products.Count
        };

        // Cache the response for 5 minutes with sliding expiration
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

        cache.Set(cacheKey, response, cacheOptions);
        logger.LogInformation("Products cached successfully");

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error retrieving products");
        return Results.Problem(
            title: "Error Retrieving Products",
            detail: ex.Message,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
})
.WithName("GetProducts")
.WithOpenApi()
.Produces<ApiResponse>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status500InternalServerError)
.CacheOutput();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
