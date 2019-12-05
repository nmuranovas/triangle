namespace Triangle
{
    public interface IFileReader
    {
        /// <summary>
        /// Read string array of all lines from the specified file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string[] ReadAllLines(string path);
    }
}