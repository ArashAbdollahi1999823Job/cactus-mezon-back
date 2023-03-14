#region UsignAndNamespace
using System.Reflection;
using Application.Common.BehavioursPipe;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Application;
#endregion
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        #region PipeLine
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(BehavioursPerformance<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(BehavioursCacheQuery<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(BehavioursValidators<,>));
        #endregion
        
        //validator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //autoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //CQRS
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}

