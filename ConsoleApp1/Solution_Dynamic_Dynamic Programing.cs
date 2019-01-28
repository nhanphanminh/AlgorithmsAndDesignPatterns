namespace ConsoleApp1
{
    public partial class Solution
    {
        // Max Rectangle in Binary Matrix
        //Given a 2D binary matrix filled with 0’s and 1’s, find the largest rectangle containing all ones and return its area.

        //    Bonus if you can solve it in O(n^2) or less.

        //    Example :

        //A : [  1 1 1
        //       0 1 1
        //       1 0 0]

        //Output : 4 

        //As the max area rectangle is created by the 2x2 rectangle created by (0,1), (0,2), (1,1) and(1,2)
        public int maximalRectangle(List<List<int>> A)
        {
            int n = A.Count;
            if (n == 0) return 0;
            int m = A[0].Count;
            if (m == 0) return 0;
            int[,] sumtl = new int[n, m];
            //compute sum from top-left
            for (var i = 0; i < n; i++)
            {
                var sumRow = 0;
                for (var j = 0; j < m; j++)
                {
                    sumRow += A[i][j];
                    sumtl[i, j] = sumRow;
                    if (i > 0) sumtl[i, j] += sumtl[i - 1, j];
                }
            }
            //for each point pair, check if valid and compute max area
            var maxArea = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    var intersection = i > 0 && j > 0 ? sumtl[i - 1, j - 1] : 0;
                    for (var k = i; k < n; k++)
                    {
                        for (var l = j; l < m; l++)
                        {
                            //compute sum of (i,j)x(k,l) matrix
                            var top = i > 0 ? sumtl[i - 1, l] : 0;// i-1, l
                            var left = j > 0 ? sumtl[k, j - 1] : 0; //k, j-1
                            var sum = sumtl[k, l] + intersection - top - left;
                            //If sum == area then it's valid
                            var area = (k - i + 1) * (l - j + 1);
                            if (area == sum && area > maxArea)
                            {
                                maxArea = area;
                            }
                        }
                    }
                }
            }
            return maxArea;
        }
    }
}





