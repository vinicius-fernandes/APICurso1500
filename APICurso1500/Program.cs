using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APICurso1500.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<APICurso1500Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APICurso1500Context") ?? throw new InvalidOperationException("Connection string 'APICurso1500Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
