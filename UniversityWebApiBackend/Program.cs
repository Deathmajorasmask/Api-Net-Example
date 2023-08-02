// 1: Usings to work EntityFrameworkCore
using Microsoft.EntityFrameworkCore;
using UniversityWebApiBackend.DataAccess;
using UniversityWebApiBackend.Services;
using UniversityWebApiBackend;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 2: Connection DBSQL
const string CONNECTION_NAME = "DBContext";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME);

// 3: Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Services of JWT autorization
builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();

// 4: Add Custom Services (folder Services)
builder.Services.AddScoped<IStudentsService, StudentsService>();
    // TODO: Add the rest of services

// 8. Add authorization 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9. Configuration Swagger to take care of autorization of JWT
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    // Define the Security for authorization 
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header Using Bearer Schema"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

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
