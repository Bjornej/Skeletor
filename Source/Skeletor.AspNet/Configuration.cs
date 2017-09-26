namespace Skeletor.AspNet
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///     Helper class to contain Skeletor configurations for aspnet
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        ///     Registers all Skeletor defined services to be able to use them in an aspNet project
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <returns>Configured application builder</returns>
        public static IServiceCollection AddSkeletor(this IServiceCollection services)
        {
            var host = (IHostingEnvironment)services.FirstOrDefault(d => d.ServiceType == typeof(IHostingEnvironment))?.ImplementationInstance;
            var discoverer = new DefaultAssemblyDiscoverer();
            var assemblies = discoverer.FindAssemblies(host.ApplicationName);

            RegisterHandlers(assemblies, services);

            return services;
        }

        /// <summary>
        ///     Resgisters all command handlers as scoped services
        /// </summary>
        /// <param name="assemblies">Assemblies to examine</param>
        /// <param name="services">Service collection</param>
        private static void RegisterHandlers(IEnumerable<Assembly> assemblies, IServiceCollection services)
        {
            services.AddScoped<ICommandExecutor, DefaultCommandExecutor>();
            services.AddScoped<ICommandHandlerFactory, DefaultCommandHandlerFactory>();

            var handlers = TypeHelpers.GetCommandHandlers(assemblies);
            foreach (var type in handlers)
            {
                services.Add(new ServiceDescriptor(type.Interface, type.Type, ServiceLifetime.Scoped));
            }
        }

        /// <summary>
        ///     Configures Skeletor for usage within an owin application
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <returns>Configured application builder</returns>
        public static IApplicationBuilder UseSkeletor(this IApplicationBuilder app)
        {           
            return app;
        }
    }
}
