using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using basic_api.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Quartz;



DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("./firebase.json"),
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .WithExposedHeaders("Access-Control-Allow-Origin");
        });
});

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");
logger.LogInformation($"Connection String: {connectionString}");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<ICarInterface, CarRepository>();
builder.Services.AddScoped<ICarTypeInterface, CarTypeRepository>();
builder.Services.AddScoped<ICarBrandInterface, CarBrandRepository>();
builder.Services.AddScoped<IOrderInterface, OrderRepository>();
builder.Services.AddScoped<IPaymentInterface, PaymentRepository>();
builder.Services.AddScoped<ICouponInterface, CouponRepository>();
builder.Services.AddScoped<IPunishmentInterface, PunishmentRepository>();
// builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<Service>();

builder.Services.AddScoped<IPayOsInterface, PayOsService>();
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("DailyJob");
    q.AddJob<DailyJob>(opts => opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DailyTrigger")
        .WithCronSchedule("0 0 7 * * ?", x => x.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"))));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var serviceProvider = scope.ServiceProvider;

//     var service = serviceProvider.GetRequiredService<Service>();
//     var orderRepo = serviceProvider.GetRequiredService<IOrderInterface>();
//     var userRepo = serviceProvider.GetRequiredService<IUserInterface>();

//     var dailyJob = new DailyJob(service, orderRepo, userRepo);

//     try
//     {
//         await dailyJob.Execute(null);
//         Console.WriteLine("DailyJob ?ã ???c th?c thi th? công.");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"L?i khi ch?y DailyJob: {ex.Message}");
//     }
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();