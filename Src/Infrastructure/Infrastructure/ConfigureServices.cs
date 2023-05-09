using System.Text;
using Application.Common.Messages;
using Application.IContracts.IBase;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
using Domain.Entities.IdentityEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Contract.Base;
using Infrastructure.Persistence.Contract.Repository;
using Infrastructure.Persistence.Contract.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using Role = Domain.Entities.IdentityEntity.Role;
namespace Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        #region AddContextService
        services.AddDbContext<ApplicationDbContext>(x =>
        {
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        #endregion

        #region AddRedis
        services.AddSingleton<IConnectionMultiplexer>(x =>
        {
            var option = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
            return ConnectionMultiplexer.Connect(option);
        });
        #endregion

        #region AddIdentity
        services
            .AddIdentityCore<User>()
            .AddUserManager<UserManager<User>>()
            .AddSignInManager<SignInManager<User>>()
            .AddTokenProvider("MyApp", typeof(DataProtectorTokenProvider<User>))
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        #endregion

        #region ConfigureIdentity
        services.Configure<IdentityOptions>(x =>
        {
            //password setting
            x.Password.RequireDigit = false;
            x.Password.RequireLowercase = false;
            x.Password.RequireUppercase = false;
            x.Password.RequiredLength = 8;
            x.Password.RequiredUniqueChars = 0;
            x.Password.RequireNonAlphanumeric = false;

            //lockout setting
            x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            x.Lockout.MaxFailedAccessAttempts = 5;
            x.Lockout.AllowedForNewUsers = true;

            //user setting
            x.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        });
        #endregion
        
        //policy
        services.AddAuthorization();
        
        // Jwt

        #region Authentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.SaveToken = true; 
                x.TokenValidationParameters = OptionsTokenValidationParameters(configuration);
                x.Events = JwtOptionsEvents();
            });
        #endregion
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IOffRepository, OffRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IStoreUserRepository, StoreUserRepository>();
        services.AddScoped<IStoreUserPictureRepository, StoreUserPictureRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IInventoryOperationRepository, InventoryOperationRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<ITypeItemRepository, TypeItemRepository>();
        services.AddScoped<IProductItemRepository, ProductItemRepository>();
        services.AddScoped<ITypePictureRepository, TypePictureRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }

    private static JwtBearerEvents JwtOptionsEvents()
    {
        return new JwtBearerEvents()
        {
            OnMessageReceived = x =>
            {
                var accessToken = x.Request.Query["access_token"];
                var path = x.HttpContext.Request.Path;
                if (!String.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/hubs")))
                {
                    x.Token = accessToken;
                }
                return Task.CompletedTask;
            },
            
            
            OnAuthenticationFailed = x =>
            {
                x.NoResult();
                x.Response.StatusCode = 500;
                x.Response.ContentType = "application/json";
                return x.Response.WriteAsync(ApplicationMessages.Jwt500Error);
            },
            OnChallenge = x =>
            {
                x.HandleResponse();
                x.Response.StatusCode = 401;
                x.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(new ApiToReturn(ApplicationMessages.Jwt401Error, 401));
                return x.Response.WriteAsync(result);
            },
            OnForbidden = x =>
            {
                x.Response.StatusCode = 403;
                x.Response.ContentType = "application/json";
                var result =
                    JsonConvert.SerializeObject(new ApiToReturn(ApplicationMessages.Jwt403ErrorNotAccess, 403));
                return x.Response.WriteAsync(result);
            }
        };
    }
    private static TokenValidationParameters OptionsTokenValidationParameters(IConfiguration configuration)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:Key"] ?? string.Empty)),
            ValidateIssuer = true,
            ValidIssuer = configuration["JwtConfiguration:Issuer"],
            ValidateAudience = Convert.ToBoolean(configuration["JwtConfiguration:Audience"]),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
    }
}