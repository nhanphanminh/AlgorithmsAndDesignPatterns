using System.Collections.Generic;
using System.Linq;

namespace BitInterView
{
    public partial class Solution
    {
        //Given an array of positive elements, you have to flip the sign of some of its elements such that the resultant sum of the elements of array should be minimum non-negative(as close to zero as possible). Return the minimum no.of elements whose sign needs to be flipped such that the resultant sum is minimum non-negative.

        //    Constraints:

        //1 <= n <= 100
        //Sum of all the elements will not exceed 10,000.

        //Example:

        //A = [15, 10, 6]
        //ans = 1(Here, we will flip the sign of 15 and the resultant sum will be 1)

        //A = [14, 10, 4]
        //ans = 1(Here, we will flip the sign of 14 and the resultant sum will be 0)

        public int GetWeight(int[] numberArray)
        {
            var W = 0;

            foreach (var i in numberArray)
            {
                W += i;
            }

            return W/2;
        }

        public int solve(List<int> A)
        {
            var numberArray = A.ToArray();
            var W = GetWeight(numberArray);
            var maxValues = new int[A.Count + 1, W + 1];
            var resultStep = new int[A.Count + 1, W + 1];

            for (int i = 0; i <= W; i++)
            {
                maxValues[0,i] = 0;
                resultStep[0,i] = 0;
            }

            var FlipSteps = -1;
            var Max = -1;

            for (var i = 1; i <= A.Count; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    //wij is also values of ij( Vij )
                    var wij = A[i-1];

                    // capacity is less than weight, return zero
                    if (wij > j)
                    {
                        maxValues[i, j] = maxValues[i - 1, j];
                        resultStep[i, j] = resultStep[i - 1, j];
                    }
                    else
                    {
                        var tmp = maxValues[i - 1, j - wij] + wij;
                        var tmpSteps = resultStep[i - 1, j - wij] + 1;

                        if (tmp < maxValues[i - 1, j] ||
                            (tmp == maxValues[i - 1, j] && tmpSteps > resultStep[i - 1, j]))
                        {
                            tmp = maxValues[i - 1, j];
                            tmpSteps = resultStep[i - 1, j];
                        }

                        maxValues[i, j] = tmp;
                        resultStep[i, j] = tmpSteps;

                        if (Max < tmp || (Max == tmp && FlipSteps > tmpSteps))
                        {
                            Max = tmp;
                            FlipSteps = tmpSteps;
                        }
                    }
                }
            }

            return FlipSteps;
        }
    }
}





