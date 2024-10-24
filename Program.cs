using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");
logger.LogInformation(connectionString);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IStockRepository, CarTypeRepository>();
builder.Services.AddScoped<ICommentRepository, CarRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
