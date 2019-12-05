using AddressBook.Application.Contacts;
using AddressBook.Core.Contacts;
using AddressBook.Infrastructure.UnitOfWork;
using AddressBook.Repository;
using AddressBook.Repository.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AddressBook.API.Configurations
{
    public static class IoCConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services, configuration);
            ConfigureDomainServices(services, configuration);
            ConfigureApplicationServices(services, configuration);
        }

        private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddressBookContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("AddressBook"),
                    x => x.MigrationsAssembly(typeof(AddressBookContext).GetTypeInfo().Assembly.GetName().Name));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IContactRepository, ContactRepository>();
        }

        private static void ConfigureDomainServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IContactManager, ContactManager>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IContactService, ContactService>();
        }
    }
}