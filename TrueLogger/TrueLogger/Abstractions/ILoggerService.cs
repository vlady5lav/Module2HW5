namespace TrueLogger
{
    public interface ILoggerService
    {
        string Log { get; }
        string Path { get; }

        void LogEventError(string msg);
        void LogEventInfo(string msg);
        void LogEventWarning(string msg);
    }
}