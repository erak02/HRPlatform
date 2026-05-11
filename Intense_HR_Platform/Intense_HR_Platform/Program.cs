using Intense_HR_Platform.Models;
using Intense_HR_Platform.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DbCon"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DbCon"))));

// Register JobCandidateSkillService as the implementation of IJobCandidateSkillService
// AddScoped means a new instance is created for each HTTP request
builder.Services.AddScoped<IJobCandidateSkillService, JobCandidateSkillService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
