using System;

namespace TrueLogger
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfigService _configService;
        private readonly IDisposable _streamWriter;
        private readonly IFileService _fileService;
        private readonly string _filePath;

        public LoggerService(
            IConfigService configService,
            IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _filePath = _configService.FilePath;
            _streamWriter = StreamPrepairer();
        }

        /*
         * Not needed in our case
         *
        ~LoggerService()
        {
            _fileService.CloseFileStream(_streamWriter);
            _streamWriter.Dispose();
        }
        */

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

        public void LogEvent(LogLevel logLevel, string msg)
        {
            var logMsg = $"{DateTime.UtcNow.ToString(_configService.TimeFormat)}: {logLevel}: {msg}";
            Console.WriteLine(logMsg);
            LogWrite(logMsg);
        }

        private IDisposable StreamPrepairer()
        {
            _fileService.MakeDir(_configService.DirPath);
            _fileService.CleanDir(_configService.DirPath, _configService.DirSize);
            _fileService.MakeFile(_filePath);
            return _fileService.OpenFileStream(_filePath);
        }

        private void LogWrite(string txt)
        {
            _fileService.WriteLineToFile(_streamWriter, txt);
        }
    }
}
