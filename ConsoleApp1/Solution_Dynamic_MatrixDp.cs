using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        // Unique Paths in a Grid
        //Given a grid of size m * n, lets assume you are starting at(1,1) and your goal is to reach(m, n). At any instance, if you are on(x, y), you can either go to(x, y + 1) or(x + 1, y).

        //Now consider if some obstacles are added to the grids.How many unique paths would there be?
        //    An obstacle and empty space is marked as 1 and 0 respectively in the grid.

        //    Example :
        //There is one obstacle in the middle of a 3x3 grid as illustrated below.


        //[
        //[0,0,0],
        //[0,1,0],
        //[0,0,0]
        //]
        //The total number of unique paths is 2.
        private int[] XPos = { 0, 1 };
        private int[] YPos = { 1, 0 };
        private int uniquePathsWithObstacles(int[][] A, int M, int N, int x, int y)
        {
            if (x == N && y == M)
            {
                return 1;
            }

            var result = 0;

            for (int i = 0; i <= 1; i++)
            {
                var xNew = x + XPos[i];
                var yNew = y + YPos[i];

                if (xNew <= N && yNew <= M && A[xNew][yNew] == 0)
                {
                    result += uniquePathsWithObstacles(A, M, N, xNew, yNew);
                }
            }

            return result;
        }

        public int uniquePathsWithObstacles(List<List<int>> A)
        {
            if (A.Count == 0)
            {
                return 0;
            }

            if (A[0].Count == 0)
            {
                return 0;
            }

            if (A[0][0] >= 1)
            {
                return 0;
            }

            int[][] arrays = A.Select(a => a.ToArray()).ToArray();

            var N = A.Count - 1;
            var M = A[0].Count - 1;

            return uniquePathsWithObstacles(arrays, M, N, 0, 0);
        }

        // Dungeon Princess
        private void calculateMinimumHP(int[][] A, int M, int N, int x, int y, ref int[,] MinArray, ref bool[,] isChecked)
        {
            if (x == N && y == M)
            {
                if (!isChecked[x, y])
                {
                    isChecked[x, y] = true;

                    if (A[x][y] >= 0)
                    {
                        MinArray[x, y] = 1;
                    }
                    else
                    {
                        MinArray[x, y] = Math.Abs(A[x][y]) + 1;
                    }
                }

                return;
            }

            var minValue = int.MaxValue;

            for (int i = 0; i <= 1; i++)
            {
                var xNew = x + XPos[i];
                var yNew = y + YPos[i];

                if (xNew <= N && yNew <= M)
                {
                    if (!isChecked[xNew, yNew])
                    {
                        calculateMinimumHP(A, M, N, xNew, yNew, ref MinArray, ref isChecked);
                    }

                    //var tmp = Math.Min(MinArray[xNew, yNew], A[xNew][yNew]);
                    minValue = Math.Min(minValue, MinArray[xNew, yNew]);
                }
            }

            var currentMinValue = A[x][y] - minValue;
            MinArray[x, y] = currentMinValue >= 0 ? 1 : Math.Abs(currentMinValue);
            isChecked[x, y] = true;
        }

        public int calculateMinimumHP(List<List<int>> A)
        {
            if (A.Count == 0)
            {
                return 0;
            }

            if (A[0].Count == 0)
            {
                return 0;
            }

            int[][] arrays = A.Select(a => a.ToArray()).ToArray();

            var N = A.Count - 1;
            var M = A[0].Count - 1;
            int[,] minArray = new int[N + 1, M + 1];
            bool[,] isChecked = new bool[N + 1, M + 1];
            calculateMinimumHP(arrays, M, N, 0, 0, ref minArray, ref isChecked);

            return minArray[0, 0];
        }

    }
}





