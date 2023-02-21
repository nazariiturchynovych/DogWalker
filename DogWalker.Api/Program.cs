using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using DogWalker.Api.Application.ServiceConfiguration;
using DogWalker.Domain.Entities.User;
using DogWalker.Domain.Options;
using DogWalker.Domain.Repositories;
using DogWalker.Domain.Repositories.UnitOfWork;
using DogWalker.Infrastructure.DataBase.DogWalkerDbContext;
using DogWalker.Infrastructure.Repositories.UnitOfWork;
using DogWalker.Infrastructure.Services.CurrentUserService;
using DogWalker.Infrastructure.Services.EMailService;
using DogWalker.Infrastructure.Services.ImageService;
using DogWalker.Infrastructure.Services.JWTTokenGeneratorService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DogWalkerDbContext>(
    options =>
    {
        options.UseNpgsql(
            o =>
            {
                o.CommandTimeout(300);
            });
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services
    .AddIdentity<User, Role>()
    .AddUserManager<UserManager<User>>()
    .AddEntityFrameworkStores<DogWalkerDbContext>()
    .AddDefaultTokenProviders();

var configurationSettings = new JwtSettingsOptions();
builder.Configuration.Bind(nameof(JwtSettingsOptions), configurationSettings);

var googleAuthOptions = new GoogleAuthOptions();
builder.Configuration.Bind($"Authentication:{nameof(GoogleAuthOptions)}", googleAuthOptions);

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services
    .AddAuthentication(
        options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                //TODO change from false to configurationSettings
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configurationSettings.Issuer,
                ValidAudience = configurationSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationSettings.Secret)),
            };
        }) //TODO move to extensions
    .AddGoogle(
        options =>
        {
            options.ClientId = googleAuthOptions.ClientId;
            options.ClientSecret = googleAuthOptions.ClientSecret;
        });

//TODO move to extensions
builder.Services.Configure<SMTPOptions>(builder.Configuration.GetSection(nameof(SMTPOptions)));
builder.Services.Configure<GoogleAuthOptions>(builder.Configuration.GetSection($"Authentication:{nameof(GoogleAuthOptions)}"));
builder.Services.Configure<JwtSettingsOptions>(builder.Configuration.GetSection(nameof(JwtSettingsOptions)));



builder.Services.AddScoped(typeof(IImageService<>), typeof(ImageService<>));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalkerRepository, WalkerRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();



builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped(
    x => x
        .GetRequiredService<IUrlHelperFactory>()
        .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext!));

//TODO move to extensions
builder.Services.AddMemoryCache();

builder.Services.ConfigureIdentity();

builder.Services.AddMvc()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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