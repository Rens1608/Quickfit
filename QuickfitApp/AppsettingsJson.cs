using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuickfitApp
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

        public static string GetTestConnectionstring()
        {
            var configuration = GetAppSettings();
            return configuration.GetSection("DatabaseSettings").GetSection("TestConnectionString").Value;
        }
    }
}
