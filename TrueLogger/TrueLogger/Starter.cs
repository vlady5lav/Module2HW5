using Microsoft.Extensions.DependencyInjection;

namespace TrueLogger
{
    public class Starter
    {
        private App _app;

        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfigService, ConfigService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<IActionService, ActionService>()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<App>()
                .BuildServiceProvider();

            _app = serviceProvider.GetService<App>();
            _app.Start();
        }
    }
}
