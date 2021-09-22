using System;
using System.Text;

namespace TrueLogger
{
    public class LoggerService : ILoggerService
    {
        private readonly StringBuilder _log;
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;

        private readonly string _path;
        private readonly string _dir;
        private readonly string _extension;
        private readonly string _fileNameFormat;
        private readonly string _timeFormat;

        public LoggerService(
            IConfigService configService,
            IFileService fileService)
        {
            _log = new StringBuilder();
            _configService = configService;
            _fileService = fileService;

            _dir = _configService.DirConfig.DirPath;
            _fileNameFormat = _configService.LoggerConfig.FileNameFormat;
            _timeFormat = DateTime.UtcNow.ToString(_configService.LoggerConfig.TimeFormat);
            _extension = _configService.LoggerConfig.FileExtension;

            _path = $"{_dir}{_fileNameFormat}{_timeFormat}{_extension}";
        }

        public string Log => _log.ToString();

        public string Path => _path;

        public void LogEventInfo(string msg)
        {
            LogEvent(LogLevel.Info, msg);
        }

        public void LogEventWarning(string msg)
        {
            LogEvent(LogLevel.Warning, msg);
        }

        public void LogEventError(string msg)
        {
            LogEvent(LogLevel.Error, msg);
        }

        private void LogEvent(LogLevel logLevel, string msg)
        {
            var logMsg = $"{DateTime.UtcNow.ToString(_configService.LoggerConfig.TimeFormat)}: {logLevel}: {msg}";
            Console.WriteLine(logMsg);
            LogWrite(logMsg);
        }

        private void LogWrite(string txt)
        {
            _fileService.WriteLine(_path, txt);
        }
    }
}
