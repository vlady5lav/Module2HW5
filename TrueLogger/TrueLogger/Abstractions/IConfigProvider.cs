namespace TrueLogger
{
    public interface IConfigProvider
    {
        Config Config { get; }
        DirConfig DirConfig { get; }
        LoggerConfig LoggerConfig { get; }
    }
}