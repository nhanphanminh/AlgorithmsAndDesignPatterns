using BitInterView;
using System.Collections.Generic;

namespace BitInterView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution(2);

            var rs3 = solution.uniquePathsWithObstacles(new List<List<int>>
            {
                new List<int>{0,0,0},
                new List<int>{0,0,0}
            });
        }
    }
}

