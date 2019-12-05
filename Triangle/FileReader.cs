using System.IO;

namespace Triangle
{
    /// <summary>
    /// Contains methods for file operations.
    /// </summary>
    public class FileReader : IFileReader
    {
        /// <summary>
        /// Read string array of all lines from the specified file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}