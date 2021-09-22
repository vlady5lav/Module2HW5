using System;
using System.IO;

namespace TrueLogger
{
    public class FileService : IFileService
    {
        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteToFile(string path, string txt)
        {
            File.WriteAllText(path, txt);
        }

        public void WriteLine(string path, string txt)
        {
            using var streamWriter = new StreamWriter(path, true, System.Text.Encoding.Default);
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine(txt);
            streamWriter.Flush();
        }

        public void MakeFile(string path)
        {
            var file = new FileInfo(path);

            if (!file.Exists)
            {
                file.Create().Close();
            }
        }

        public void MakeDir(string path)
        {
            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        public void CleanDir(string path, int size)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles();

            if (files.Length >= size)
            {
                Array.Sort(files, new FilesComparer());

                for (var i = 0; i <= files.Length - size; i++)
                {
                    File.Delete(files[i].FullName);
                }
            }
        }
    }
}
