namespace TrueLogger
{
    public interface IConfigService
    {
        Config Config { get; }
        DirConfig DirConfig { get; }
        string DirPath { get; }
        int DirSize { get; }
        string FilePath { get; }
        LoggerConfig LoggerConfig { get; }
        string TimeFormat { get; }
    }
}