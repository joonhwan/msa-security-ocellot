using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace RabbitMQ.Queue.Producer
{
    public class ConfigHelper
    {
        public static IConfiguration GetAppSettingsConfig()
        {
            var fileName = "appsettings.json";
            var configDir = GuessConfigDirectory(fileName);
            if (configDir == null)
            {
                Console.WriteLine("Unable to get Config Directory");
                Environment.Exit(-1);
            }
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(configDir)
                    .AddJsonFile(fileName, false)
                    .Build()
                ;
            return configuration;
        }
        public static string GuessConfigDirectory(string fileName)
        {
            var configDir = AppContext.BaseDirectory;
            while (true)
            {
                try
                {
                    var configPath = Path.Combine(configDir, fileName);
                    if (File.Exists(configPath))
                    {
                        return configDir;
                    }
                    configDir = Directory.GetParent(configDir).FullName;
                }
                catch (Exception)
                {
                    break;
                }
            }

            return null;
        }
    }
}