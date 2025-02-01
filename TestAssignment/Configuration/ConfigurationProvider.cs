using Microsoft.Extensions.Configuration;

namespace TestAssignment.Configuration
{
    internal class ConfigurationProvider
    {
        private static ConfigurationManager _configuration;
        public static ConfigurationManager Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationManager();
                    _configuration
                        .AddJsonFile("appsettings.json", optional: true, false);
                }
                return _configuration;
            }
        }
    }
}
