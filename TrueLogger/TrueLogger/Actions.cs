using System;

namespace TrueLogger
{
    public class Actions
    {
        private readonly ILoggerService _loggerService;

        public Actions(
            ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool InfoLog()
        {
            _loggerService.LogEventInfo($"Start method: {nameof(InfoLog)}");
            return true;
        }

        public bool WarningLog()
        {
            throw new BusinessException($"Skipped logic in method: {nameof(WarningLog)}");
        }

        public bool ErrorLog()
        {
            throw new Exception("I broke a logic");
        }
    }
}
