using System;

namespace TrueLogger
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        private readonly Config _config;

        private readonly string _dirPath;
        private readonly string _extension;
        private readonly string _fileNameFormat;
        private readonly string _timeFormat;
        private readonly string _filePath;

        public ConfigService(
            IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _config = _configProvider.Config;

            _dirPath = _config.DirConfig.DirPath;
            _fileNameFormat = _config.LoggerConfig.FileNameFormat;
            _timeFormat = DateTime.UtcNow.ToString(_config.LoggerConfig.TimeFormat);
            _extension = _config.LoggerConfig.FileExtension;

            _filePath = $"{_dirPath}/{_fileNameFormat}{_timeFormat}{_extension}";
        }

        public Config Config => _config;
        public DirConfig DirConfig => _config.DirConfig;
        public LoggerConfig LoggerConfig => _config.LoggerConfig;
        public int DirSize => _config.DirConfig.DirSize;
        public string DirPath => _config.DirConfig.DirPath;
        public string FilePath => _filePath;
        public string TimeFormat => _config.LoggerConfig.TimeFormat;
    }
}
