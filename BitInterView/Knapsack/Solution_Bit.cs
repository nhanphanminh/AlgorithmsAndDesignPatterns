using System.Linq;

namespace BitInterView
{
    public partial class Solution
    {
        public int solve(int A, int B)
        {

            long[] prev = new long[B + 1];
            prev[0] = 1;

            long[] current = new long[B + 1];

            for (int i = 0; i < A; ++i)
            {
                for (int b = 0; b <= B; ++b)
                {
                    long sum = 0;
                    int k = (i == A - 1) ? 1 : 0;

                    for (; k < 10; ++k)
                    {
                        int remaining = b - k;
                        if (remaining < 0) { continue; }
                        sum = (sum + prev[remaining]) % 1000000007;
                    }

                    current[b] = sum;
                }

                long[] tmp = prev;
                prev = current;
                current = tmp;
            }

            return (int)prev.Last();
        }
    }
}





