using DelabinService.Contracts.Interfaces;
using DelabinService.Repository;

namespace DelabinService
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
