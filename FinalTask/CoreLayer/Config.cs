using Microsoft.Extensions.Configuration;

namespace FinalTask.CoreLayer
{
    internal class Config
    {
        public static string BrowserType { get; private set; }

        public static string AppUrl { get; private set; }

        public static int implicitWaitTime { get; private set; }

        static Config()
        {
            Init();
        }

        public static void Init()
        {
            var configuration = new ConfigurationBuilder()  
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            BrowserType = configuration["BrowserType"] ?? "Edge";
            AppUrl = configuration["ApplicationUrl"] ?? string.Empty;
            implicitWaitTime = int.TryParse(configuration["ImplicitWaitTime"], out var value) && value >= 0 ? value : 10;
        }
    }
}
