using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace theory_testing
{
    public interface ISettingsCodex
    {
        IConfigurationRoot GetAppConfig();
        string GetConnectionString();
    }

    public class SettingsCodex : ISettingsCodex
    {
        private IConfigurationRoot configuration;

        public SettingsCodex()
        {
            configuration = this.GetAppConfig();
        }

        public IConfigurationRoot GetAppConfig()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            return configBuilder.Build();
        }

        public string GetConnectionString()
        {
            if (configuration["ConnectionString"] != null)
            {
                return configuration["ConnectionString"];
            }
            else
            {
                throw new Exception("ConnectionString key not found.");
            }
        }
    }
}
