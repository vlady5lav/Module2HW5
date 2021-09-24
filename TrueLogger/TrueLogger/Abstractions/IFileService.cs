using System;

namespace TrueLogger
{
    public interface IFileService
    {
        void CleanDir(string path, int size);
        void CloseFileStream(IDisposable iDisposable);
        void MakeDir(string path);
        void MakeFile(string path);
        IDisposable OpenFileStream(string path);
        string ReadFromFile(string path);
        void WriteLineToFile(IDisposable iDisposable, string txt);
        void WriteToFile(string path, string txt);
    }
}