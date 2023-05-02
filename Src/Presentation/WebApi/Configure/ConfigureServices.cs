using System.Text.Json.Serialization;
using Application;
using Application.IContracts.IServices;
using Domain.Exceptions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Services;
using WebApi.Extensions;
using WebApi.SignalR;

namespace WebApi.Configure;
public static class ConfigureServices
{
    public static IServiceCollection AddWebService(this WebApplicationBuilder builder)
    {
        #region OriginalServices
        ApiBehaviorOptions(builder);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocumentation();
        builder.Services.AddControllers().AddJsonOptions(options => 
        { 
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        builder.Services.AddSignalR();
        #region SettingCorsPolicy
        builder.Services.AddCors(x =>
        {
            x.AddPolicy("CorsPolicy", policy =>
            {
                policy.
                    AllowCredentials()
                    .WithOrigins(builder.Configuration["FrontUrl:AddressHttp"] ?? string.Empty
                        , builder.Configuration["FrontUrl:AddressHttps"] ?? string.Empty
                        ,builder.Configuration["FrontAdminUrl:AddressHttp"] ?? string.Empty
                        , builder.Configuration["FrontAdminUrl:AddressHttps"] ?? string.Empty)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        }); 
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();
        #endregion
        #endregion

        #region ManualServices
        builder.Services.AddTransient<IFileUploader, FileUploader>();
        builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
        builder.Services.AddSingleton<PresenceTracker>();
        builder.Services.AddApplicationService();
        builder.Services.AddInfrastructureService(builder.Configuration);
        #endregion

        return builder.Services;
    }
    #region MethodSettingApiBehaviorOptions
    private static void ApiBehaviorOptions(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>(x =>
        {
            x.InvalidModelStateResponseFactory = x =>
            {
                var errors = x.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToList();
                return new BadRequestObjectResult(new ApiToReturn(errors, 400));
            };
        });
    } 
    #endregion
}

