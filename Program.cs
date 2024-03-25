using Microsoft.EntityFrameworkCore;
using PokemonApp;
using PokemonApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add database connection
// Skriv den før builder.Build()

//Vi henter connnectionString fra vores user secret ud fra key "default"
var connectionString = builder.Configuration.GetConnectionString("default");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<DataContext>(options =>
{
    //Vi giver connectionString som argument
    options.UseMySql(connectionString, serverVersion)
    //Nedenstående kun til dev. Slet ved deployment
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});


var app = builder.Build();




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
