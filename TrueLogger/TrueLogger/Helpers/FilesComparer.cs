using System.Collections;
using System.IO;

namespace TrueLogger
{
    public class FilesComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var file1 = x as FileInfo;
            var file2 = y as FileInfo;

            return file1.LastWriteTime.CompareTo(file2.LastWriteTime);
        }
    }
}
