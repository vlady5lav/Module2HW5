namespace TrueLogger
{
    public interface IConfigService
    {
        Config Config { get; }
        DirConfig DirConfig { get; }
        LoggerConfig LoggerConfig { get; }
    }
}