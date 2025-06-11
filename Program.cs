using Restaurants.Extensions;
using Restaurants.Seeders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestuarantSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
