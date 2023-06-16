using System.Reflection;

namespace LobbyWars.APIv1
{
    /// <summary>
    /// Dependency injection class.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add to application the different dependecy injection.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <returns>IServiceCollection with dependencies.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Add IoC references:
            // https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection
            services.AddTransient<Application.Interfaces.IMininumSignatureQuery, Application.Queries.MininumSignatureQuery>();
            services.AddTransient<Application.Interfaces.IWinnerContractQuery, Application.Queries.WinnerContractQuery>();

            // Add MediatR Commands/Envents.
            services.AddProcessServices();

            return services;
        }

        /// <summary>
        /// Contains the services related to Mediatr.
        /// </summary>
        /// <param name="services">IServiceCollection object.</param>
        /// <returns>IServiceCollection with dependencies.</returns>
        private static IServiceCollection AddProcessServices(this IServiceCollection services)
        {
            // Add MediatR Commands/Envents.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application.Commands.GetMinimumSignatureNecessaryToWin).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application.Commands.GetWinnerContract).GetTypeInfo().Assembly));

            return services;
        }
    }
}
