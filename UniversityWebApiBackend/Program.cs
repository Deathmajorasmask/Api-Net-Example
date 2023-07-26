// 1: Usings to work EntityFrameworkCore
using Microsoft.EntityFrameworkCore;
using UniversityWebApiBackend.DataAccess;
using UniversityWebApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 2: Connection DBSQL
const string CONNECTION_NAME = "DBContext";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

// 3: Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Services of JWT autorization
//builder.Services.AddJwtTokenService(builder.Configuration);


builder.Services.AddControllers();

// 4: Add Custom Services (folder Services)
builder.Services.AddScoped<IStudentsService, StudentsService>();
    // Add the rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8. Configuration Swagger to take care of autorization of JWT
builder.Services.AddSwaggerGen();

// 5: CORS Configuration 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
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

// 6: Tell app to use Cors
app.UseCors("CorsPolicy");

app.Run();
