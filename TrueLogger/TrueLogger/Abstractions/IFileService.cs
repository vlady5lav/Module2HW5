namespace TrueLogger
{
    public interface IFileService
    {
        void CleanDir(string path, int size);
        void MakeDir(string path);
        void MakeFile(string path);
        string ReadFromFile(string path);
        void WriteLine(string path, string txt);
        void WriteToFile(string path, string txt);
    }
}