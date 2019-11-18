using System.IO;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DataLayer
{
    public static class AppSettingsJson
    {
        public static IConfigurationRoot GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        public static string GetConnectionstring()
        {
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            var connectionString = appSettingsJson["DatabaseSettings:ConnectionString"];
            return connectionString;
        }
    }
}
