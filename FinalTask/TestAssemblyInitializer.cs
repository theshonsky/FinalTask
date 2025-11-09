using log4net;
using log4net.Config;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FinalTask
{
    public static class TestAssemblyInitializer
    {
        [ModuleInitializer]
        public static void Init()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
