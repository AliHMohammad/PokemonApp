using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;
using PokemonApp.Repositories;
using PokemonApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Husk at tilf�je dine dependency injections (b�de service og repository) l�bende i Program.cs
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();



//Tilf�j Custom Exceptionhandlers
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddProblemDetails();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add database connection
// Skriv den f�r builder.Build()

//Vi henter connnectionString fra vores user secret ud fra key "default"
var connectionString = builder.Configuration.GetConnectionString("default");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<DataContext>(options =>
{
    //Vi giver connectionString som argument
    options.UseMySql(connectionString, serverVersion)
    //Nedenst�ende kun til dev. Slet ved deployment
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

// Vi bruger global exceptionhandlers
app.UseExceptionHandler();


//K�r dine migrations ved opstart af api-server
using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
await dbContext.Database.EnsureDeletedAsync();
await dbContext.Database.MigrateAsync();


app.Run();


