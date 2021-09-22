namespace TrueLogger
{
    public interface ILoggerService
    {
        void LogEventError(string msg);
        void LogEventInfo(string msg);
        void LogEventWarning(string msg);
    }
}