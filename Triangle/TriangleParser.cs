using System;
using System.Linq;

namespace Triangle
{
    /// <summary>
    /// Defines methods for string parsing into 2D arrays
    /// </summary>
    public class TriangleParser
    {
        private readonly IFileReader _fileReader;

        /// <summary>
        /// Creates a new instance of <see cref="TriangleParser"/>.
        /// </summary>
        /// <param name="fileReader"></param>
        public TriangleParser(IFileReader fileReader)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader), "FileReader class must be specified.");
        }

        /// <summary>
        /// Parses given triangle input into a 2D array.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>A jagged 2D array</returns>
        /// <exception cref="ArgumentException"></exception>
        public int[][] ParseInput(string filePath)
        {
            var lines = _fileReader.ReadAllLines(filePath);

            if (lines.Length < 1)
                throw new ArgumentException("File must not be empty");

            var resultArr = new int[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var symbols = lines[i].Split(" ");
                if (symbols.Length != i + 1)
                    throw new ArgumentException("Invalid input file - it must be of triangle text type");
                resultArr[i] = symbols.Select(int.Parse).ToArray();
            }

            return resultArr;
        }
    }
}