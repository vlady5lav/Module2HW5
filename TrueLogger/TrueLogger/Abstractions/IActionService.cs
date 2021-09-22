namespace TrueLogger
{
    public interface IActionService
    {
        bool ErrorLog();
        bool InfoLog();
        bool WarningLog();
    }
}