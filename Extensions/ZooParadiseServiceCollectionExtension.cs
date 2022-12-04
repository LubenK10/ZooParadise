using ZooParadise.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ZooParadiseServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
