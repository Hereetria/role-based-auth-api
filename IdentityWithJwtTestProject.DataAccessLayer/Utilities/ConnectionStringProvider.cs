using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityWithJwtTestProject.DataAccessLayer.Utilities
{
    public static class ConnectionStringProvider
    {
        public static string DestopConnectionString { get; } = "DesktopDefaultConnection";
        public static string LaptopConnectionString { get; } = "LaptopDefaultConnection";
        public static string GetConnectionString(string connectionStringName)
        {
            var webApiPath = ProjectPathProvider.GetApiProjectPath();

            var jsonFilePath = Path.Combine(webApiPath, "appsettings.json");

            if (!File.Exists(jsonFilePath))
                throw new FileNotFoundException($"JSON file not found at path: {jsonFilePath}");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(jsonFilePath)!)
                .AddJsonFile(jsonFilePath)
                .Build();

            var connectionString = configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new NullReferenceException($"Connection string connection string not found in the configuration file.");

            return connectionString;
        }
    }
}
