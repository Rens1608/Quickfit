using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public static class AppSettingsJson
    {
        public static IConfigurationRoot GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public static string GetConnectionstring()
        {
            var configuration = GetAppSettings();
            return configuration.GetSection("DatabaseSettings").GetSection("ConnectionString").Value;
        }
    }
}
