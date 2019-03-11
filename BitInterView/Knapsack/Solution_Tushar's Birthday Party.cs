using System.Collections.Generic;
using System.Linq;
using System.Linq;

namespace BitInterView
{
    public partial class Solution
    {
        //As it is Tushar’s Birthday on March 1st, he decided to throw a party to all his friends at TGI Fridays in Pune.
        //    Given are the eating capacity of each friend, filling capacity of each dish and cost of each dish.A friend is satisfied if the sum of the filling capacity of dishes he ate is equal to his capacity.Find the minimum cost such that all of Tushar’s friends are satisfied (reached their eating capacity).

        //NOTE:

        //Each dish is supposed to be eaten by only one person.Sharing is not allowed.
        //    Each friend can take any dish unlimited number of times.
        //    There always exists a dish with filling capacity 1 so that a solution always exists.
        private Dictionary<int, int> GetCostDictionary(List<int> capacityDishes, List<int> costDish)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < capacityDishes.Count; i++)
            {
                if (!dict.ContainsKey(capacityDishes[i]))
                {
                    dict.Add(capacityDishes[i], costDish[i]);
                }
                else if (dict[capacityDishes[i]] > costDish[i])
                {
                    dict[capacityDishes[i]] = costDish[i];
                }
            }        

            return dict;
        }

        public int solve(List<int> A, List<int> B, List<int> C)
        {
            var maxFriendCapacity = A.Max();
            var dict = GetCostDictionary(B, C);
            var minCosts = new List<int>();
            minCosts.Add(dict[1]);

            for (int i = 2; i <= maxFriendCapacity; i++)
            {
                var minCost = -1;

                if (dict.ContainsKey(i))
                {
                    minCost = dict[i];
                }

                for (int j = 1; j < i; j++)
                {
                    if (dict.ContainsKey(j))
                    {
                        var tmp = dict[j] + minCosts[i - j -1];

                        if (minCost == -1 || minCost > tmp)
                        {
                            minCost = tmp;
                        }
                    }
                }

                minCosts.Add(minCost);
            }

            var sumCost = 0;

            for (int i = 0; i < A.Count; i++)
            {
                sumCost += minCosts[A[i]-1];
            }

            return sumCost;
        }
    }
}





