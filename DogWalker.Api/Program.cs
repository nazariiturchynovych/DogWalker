using System.Text;
using DogWalker.Api.Application.ServiceConfiguration;
using DogWalker.Domain.Entities.User;
using DogWalker.Domain.Options;
using DogWalker.Infrastructure.DataBase.DogWalkerDbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DogWalkerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentity<User, Role>()
    .AddUserManager<UserManager<User>>()
    .AddEntityFrameworkStores<DogWalkerDbContext>()
    .AddDefaultTokenProviders();


var configurationSettings = new JwtSettingsOptions();
builder.Configuration.Bind(nameof(JwtSettingsOptions), configurationSettings);

var googleAuthOptions = new GoogleAuthOptions();
builder.Configuration.Bind($"Authentication:{nameof(GoogleAuthOptions)}", googleAuthOptions);



builder.Services
    .AddAuthentication(
        options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(options =>
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
    .AddGoogle(options =>
    {
        options.ClientId = googleAuthOptions.ClientId;
            options.ClientSecret = googleAuthOptions.ClientSecret;
        });

//TODO move to extensions
builder.Services.Configure<SMTPOptions>(builder.Configuration.GetSection(nameof(SMTPOptions)));
builder.Services.Configure<GoogleAuthOptions>(builder.Configuration.GetSection($"Authentication:{nameof(GoogleAuthOptions)}"));
builder.Services.Configure<JwtSettingsOptions>(builder.Configuration.GetSection(nameof(JwtSettingsOptions)));

//TODO move to extensions
builder.Services.AddMemoryCache();

builder.Services.ConfigureIdentity();

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

