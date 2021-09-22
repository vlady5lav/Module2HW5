namespace TrueLogger
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        private readonly Config _config;

        public ConfigService(
            IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _config = _configProvider.Config;
        }

        public Config Config => _config;
        public DirConfig DirConfig => _config.DirConfig;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;
    }
}
