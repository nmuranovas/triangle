using System.Collections.Generic;
using System.Linq;

namespace Triangle
{
    /// <summary>
    /// Defines methods for 2D array traversal.
    /// </summary>
    public class TriangleTraversalService
    {
        /// <summary>
        /// Traverses the 2D triangle and finds the path where element sum is highest. If no path is found returns null.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>An array of <see cref="int"/>s</returns>
        public int[] FindHighestSumPath(int[][] array)
        {
            return FindHighestSumPath(array, new Stack<int>(), 0, 0, array[0][0] % 2 != 0);
        }

        private static int[] FindHighestSumPath(int[][] array, Stack<int> stack, int row, int column, bool prevNumIsEven)
        {
            var rowCount = array.GetLength(0);
            if (rowCount <= row)
            {
                if (stack.Count == 0) return null;

                try
                {
                    return stack.Count < rowCount ? null : stack.ToArray();
                }
                finally
                {
                    stack.Pop();
                }
            }

            var num = array[row][column];
            var thisNumIsEven = num % 2 == 0;
            if (thisNumIsEven && prevNumIsEven || !thisNumIsEven && !prevNumIsEven)
                return null;

            stack.Push(num);

            var arr1 = FindHighestSumPath(array, stack, row + 1, column, thisNumIsEven);
            var arr2 = FindHighestSumPath(array, stack, row + 1, column + 1, thisNumIsEven);

            return (arr1?.Sum() ?? 0) > (arr2?.Sum() ?? 0)
                ? arr1 : arr2;
        }
    }
}