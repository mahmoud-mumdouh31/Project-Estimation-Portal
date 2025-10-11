using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Extension.ToolKit;
//public class DependencyInjection
//{
//    /// <summary>
//    /// This method is extension method to register all services in the specified assemblies (each project assembly).
//    /// </summary>
//    /// <param name="services"></param>
//    /// <param name="assemblies"></param>
//    /// <returns><see cref="IServiceCollection"/></returns>
//    public static IServiceCollection AddServicesFromAssemblies(
//        this IServiceCollection services,
//        params Assembly[] assemblies)
//    {
//        //services.Scan(scan => scan.FromAssemblies(assemblies)
//        //     .AddClasses(classes => classes.AssignableTo<IScopedService>())
//        //     .AsImplementedInterfaces()
//        //     .WithScopedLifetime()
//        //     .AddClasses(classes => classes.AssignableTo<ITransientService>())
//        //     .AsImplementedInterfaces()
//        //     .WithTransientLifetime()
//        //     .AddClasses(classes => classes.AssignableTo<ISingletonService>())
//        //     .AsImplementedInterfaces()
//        //     .WithSingletonLifetime());

//        return services;
//    }

//}
