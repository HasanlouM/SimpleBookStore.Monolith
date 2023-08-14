using Microsoft.Extensions.Configuration;
using System;

namespace BookStore.Test.Specs
{
    public class DbConnection
    {
        public DbConnection(string connectionString, string dbName)
        {
            ConnectionString = connectionString.Replace("dbName", dbName);
            DbName = dbName;
        }

        public string ConnectionString { get; private set; }
        public string DbName { get; private set; }
    }
    internal class AppSetting
    {
        public string APIUrl { get; set; }
    }

    internal class Configuration
    {
         static Configuration()
        {
            var configurationRoot = GetRoot();
            AppSetting = configurationRoot.Get<AppSetting>();
            ConnectionString = configurationRoot.GetConnectionString("default");
        }
        public static AppSetting AppSetting { get; }
        public static string ConnectionString { get; }

        private static IConfigurationRoot GetRoot()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
