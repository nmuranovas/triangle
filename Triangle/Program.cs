using System;
using System.Linq;

namespace Triangle
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify a single file path argument.");
                return -1;
            }

            var triangleParser = new TriangleParser(new FileReader());
            var triangleTraversalService = new TriangleTraversalService();

            var parsedInput = triangleParser.ParseInput(args[0]);
            var result = triangleTraversalService.FindHighestSumPath(parsedInput);
            PrintResults(result.Reverse().ToArray());
            return 0;
        }

        private static void PrintResults(int[] path)
        {
            if (path == null)
            {
                Console.WriteLine("No valid path found.");

            }
            else
            {
                Console.WriteLine($"Max sum: {path.Sum()}");
                Console.WriteLine($"Path: {string.Join(", ", path)}");
            }
        }
    }
}