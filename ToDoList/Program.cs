using ToDoList;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DatabaseService with ADO.NET using a connection string
builder.Services.AddScoped(provider => new DatabaseService(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
