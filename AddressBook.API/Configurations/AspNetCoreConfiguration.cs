using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.API.Configurations
{
    public static class AspNetCoreConfiguration
    {
        public static void AddControllers(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllers();
        }

        public static void UseRouting(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseRouting();
        }

        public static void UseEndpoints(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}