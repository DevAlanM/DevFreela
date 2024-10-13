using DevFreela.API.Models;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var openingTime = builder.Configuration.GetSection("OpeningTime");
builder.Services.Configure<OpeningTimeOption>(openingTime);

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DevFreelaDbContext>(
    options => options.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();

//builder.Services.AddScoped<ExampleClass>(e => new ExampleClass { Name = "Initial Stage" });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
