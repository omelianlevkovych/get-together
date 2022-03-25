using GetTogether.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
await SeedDb(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task SeedDb(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    await context.Database.MigrateAsync();

    var service = services.GetService<SeedDatabase>();
    if (service == null)
    {
        throw new ArgumentNullException(nameof(service));
    }
    await service.Seed();
}