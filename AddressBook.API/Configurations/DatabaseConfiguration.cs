using AddressBook.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void UseMigrations(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AddressBookContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}