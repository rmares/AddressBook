using AddressBook.Application.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.API.Configurations
{
    public static class SignalRConfiguration
    {
        public static void AddSignalR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();
        }

        public static void UseSignalR(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>(NotificationHub.Url);
            });
        }
    }
}