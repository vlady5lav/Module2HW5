using Newtonsoft.Json;

namespace TrueLogger
{
    public class ConfigProvider : IConfigProvider
    {
        private const string ConfigFile = "config.json";

        private readonly IFileService _fileService;
        private readonly Config _config;

        public ConfigProvider(
            IFileService fileService)
        {
            _fileService = fileService;
            _config = Init();
        }

        public Config Config => _config;

        private Config Init()
        {
            _fileService.MakeFile(ConfigFile);

            var config = DeserializeConfig();

            if (config == null)
            {
                config = DefaultConfig();
                SerializeConfig(config);
                return config;
            }
            else
            {
                return config;
            }
        }

        private Config DefaultConfig()
        {
            return new Config()
            {
                DirConfig = new DirConfig()
                {
                    DirSize = 3,
                    DirPath = "logs",
                },
                LoggerConfig = new LoggerConfig()
                {
                    FileExtension = ".txt",
                    FileNameFormat = "log_",
                    TimeFormat = "yyyy.MM.dd_HH.mm.ss",
                }
            };
        }

        private Config DeserializeConfig()
        {
            var configData = _fileService.ReadFromFile(ConfigFile);
            return JsonConvert.DeserializeObject<Config>(configData);
        }

        private void SerializeConfig(Config config)
        {
            var configData = JsonConvert.SerializeObject(config);
            _fileService.WriteToFile(ConfigFile, configData);
        }
    }
}
