using Microsoft.EntityFrameworkCore;
using PokemonApp;
using PokemonApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Tilføj din application runner
builder.Services.AddTransient<Seed>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add database connection
// Skriv den før builder.Build()

//Vi henter connnectionString fra vores user secret ud fra key "default"
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<DataContext>(options =>
{
    //Vi giver connectionString som argument
    options.UseMySQL(connectionString);
});


var app = builder.Build();



//Kør din application runner
if (args.Length == 1 && args[0].ToLower() == "seeddata") SeedData(app);
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
