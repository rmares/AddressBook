using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace AddressBook.Repository
{
    /// <summary>
    /// A factory for creating AddressBookContext instance.
    /// This implementation is internally used by EF Core tools to support migrations on assembly different than application root.
    /// </summary>
    public class AddressBookContextFactory : IDesignTimeDbContextFactory<AddressBookContext>
    {
        public AddressBookContext CreateDbContext(string[] args)
        {
            var configurationFilePath = CalculateContentRootFolder();
            var builder = new ConfigurationBuilder()
                .SetBasePath(configurationFilePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configurationRoot = builder.AddJsonFile($"appsettings.Development.json", optional: true).Build();

            var optionsBuilder = new DbContextOptionsBuilder<AddressBookContext>();
            optionsBuilder.UseNpgsql(configurationRoot.GetConnectionString("AddressBook"));

            return new AddressBookContext(optionsBuilder.Options);
        }

        private static string CalculateContentRootFolder()
        {
            var assemblyName = "AddressBook.API";
            var solutionName = "AddressBook.sln";

            var coreAssemblyDirectoryPath = Path.GetDirectoryName(AppContext.BaseDirectory);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception($"Could not find location of {assemblyName} assembly!");
            }

            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            while (!DirectoryContains(directoryInfo.FullName, solutionName))
            {
                directoryInfo = directoryInfo.Parent ?? throw new Exception("Could not find content root folder!");
            }

            return Path.Combine(directoryInfo.FullName, assemblyName);
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}