using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions;
using Application.UseCases.Trains;

var builder = WebApplication.CreateBuilder(args);



// Register complete Infrastructure
    //DbContext (SQLite). Make sure ConnectionStrings:TrainDb in appsettings.json
builder.Services.AddInfrastructure(builder.Configuration);

// DI - to be able to use HandleAsync from class
builder.Services.AddScoped<CreateTrain>();



// Add services to the container.
//builder.Services.AddSingleton<Mock_Db>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.MapOpenApi();

    }

app.UseInfrastructureMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
