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
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddTransient<Actions>()
                .AddTransient<App>()
                .BuildServiceProvider();

            _app = serviceProvider.GetService<App>();
            _app.Start();
        }
    }
}
