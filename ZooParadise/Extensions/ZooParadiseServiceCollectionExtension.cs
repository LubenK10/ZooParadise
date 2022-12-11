using ZooParadise.Core.Contracts;
using ZooParadise.Core.Services;
using ZooParadise.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ZooParadiseServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IManagerService, ManagerService>();

            return services;
        }
    }
}
