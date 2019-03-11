using BitInterView;
using System.Collections.Generic;

namespace BitInterView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution(2);

            var rs1 = solution.solve(new List<int>{ 15, 10, 6 });
            var rs11 = solution.solve(new List<int>{ 14, 10, 4 });

            var rs12 = solution.solve(
                new List<int> { 2, 4, 6 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 5, 3 });
        }
    }
}

