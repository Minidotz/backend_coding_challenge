using Microsoft.EntityFrameworkCore;
using MimoBackendChallengeAPI.Services;
using MimoData.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MimoData.MimoContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("MimoConnection")));

builder.Services.AddScoped<IMimoRepository, MimoRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
