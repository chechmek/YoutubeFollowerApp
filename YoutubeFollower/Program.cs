using DataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using YoutubeFollower.Client;
using YoutubeFollower.Json;
using YoutubeFollower.Mapper;
using YoutubeFollower.Middlewares;
using YoutubeFollower.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddYoutubeClient();
builder.Services.AddFollowerRepository();
builder.Services.AddJsonConverter();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MapperProfile()));
builder.Services.AddDbContext<FollowerDbContext>(options =>
{
    string ConnectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(ConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
