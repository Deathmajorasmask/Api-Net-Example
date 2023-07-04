// 1: Usings to work EntityFrameworkCore
using Microsoft.EntityFrameworkCore;
using UniversityWebApiBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 2: Connection DBSQL
const string CONNECTION_NAME = "DBContext";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

// 3: Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


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
