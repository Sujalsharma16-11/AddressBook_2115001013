//using Microsoft.EntityFrameworkCore;
//using RepositoryLayer.Context;
//using System;

//var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

//// Database Connection
//builder.Services.AddDbContext<AppDbContext>(options =>
// options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
// new MySqlServerVersion(new Version(8, 0, 41))));
//// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

//var app = builder.Build();

//// Configure the HTTP request pipeline.


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// ✅ Get the correct connection string
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// ✅ Use the retrieved connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 41))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
