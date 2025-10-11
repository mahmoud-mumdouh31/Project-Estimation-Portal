using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Infrastructure services 
        /// (<see cref="AppDbContext"/>, 
        /// <see cref="JwtOptions"/>, 
        /// <see cref="IHttpContextAccessor"/>, 
        /// Authentication, 
        /// Authorization
        /// ) to the DI container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddServicesFromAssemblies(AssemblyReference.Assembly);
            //services.AddIdentity(configuration);


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;


        }
    }
}
