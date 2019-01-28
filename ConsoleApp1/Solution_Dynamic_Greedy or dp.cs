using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public partial class Solution
    {
        private bool CheckPath_recursion(List<int> A, int currentIndex)
        {
            if (currentIndex == A.Count - 1)
            {
                return true;
            }

            if (A[currentIndex] <= 0)
            {
                return false;
            }

            var steps = A[currentIndex];
            A[currentIndex] = 0;
            var nextIndex = currentIndex + 1;

            while (steps > 0 && nextIndex < A.Count)
            {
                if (CheckPath_recursion(A, nextIndex))
                {
                    return true;
                }

                nextIndex++;
                steps--;
            }

            return false;
        }

        private bool CheckPath(List<int> A)
        {
            var indexs = new List<int> { 0 };

            while (indexs.Count > 0)
            {
                var current = indexs[0];
                indexs.RemoveAt(0);

                if (A[current] <= 0)
                {
                    continue;
                }

                for (var steps = 1; steps <= A[current]; steps++)
                {
                    var nextIndex = current + steps;

                    if (nextIndex >= A.Count - 1)
                    {
                        return true;
                    }

                    if (A[nextIndex] == 0)
                    {
                        continue;
                    }

                    indexs.Add(nextIndex);
                }

                A[current] = 0;
            }

            return false;
        }

        public int canJump(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return 1;
            }

            if (A[0] == 0)
            {
                return 0;
            }

            return CheckPath(A) ? 1 : 0;
        }

        //public int jump(List<int> A)
        //{
        //    if (A == null || A.Count <= 1)
        //    {
        //        return 0;
        //    }

        //    if (A[0] == 0)
        //    {
        //        return -1;
        //    }

        //    var indexs = new Dictionary<int, int> { { 0, 0 } };
        //    var totalSteps = 1;

        //    while (indexs.Count > 0)
        //    {
        //        var tmp = new Dictionary<int, int>();

        //        foreach (var current in indexs.Keys)
        //        {
        //            if (A[current] <= 0)
        //            {
        //                continue;
        //            }

        //            for (var steps = 1; steps <= A[current]; steps++)
        //            {
        //                var nextIndex = current + steps;

        //                if (nextIndex > A.Count - 1)
        //                {
        //                    break;
        //                }

        //                if (nextIndex == A.Count - 1)
        //                {
        //                    return totalSteps;
        //                }

        //                if (A[nextIndex] == 0)
        //                {
        //                    continue;
        //                }

        //                if (!tmp.ContainsKey(nextIndex))
        //                {
        //                    tmp.Add(nextIndex, 0);
        //                }
        //            }

        //            A[current] = 0;
        //        }

        //        totalSteps++;
        //        indexs = tmp;
        //    }

        //    return -1;
        //}

        public int jump(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return 0;
            }

            if (A[0] == 0)
            {
                return -1;
            }

            var indexs = new Dictionary<int, int> { { 0, 0 } };
            var totalSteps = 1;
            var min = 1;
            var max = A[0];

            while (min <= max)
            {
                var tmpMin = int.MaxValue;
                var tmpMax = 0;

                for (int index = min; index <= max; index++)
                {
                    if (index == A.Count - 1)
                    {
                        return totalSteps;
                    }

                    if (A[index] == 0)
                    {
                        continue;
                    }

                    var minRange = index + 1;

                    if (tmpMin > minRange)
                    {
                        tmpMin = minRange;
                    }

                    var maxRange = A[index] + index;
                    if (tmpMax < maxRange)
                    {
                        tmpMax = maxRange;
                    }

                }

                min = tmpMin;
                max = tmpMax;

                totalSteps++;
            }

            return -1;
        }

        //It’s Tushar’s birthday today and he has N friends.Friends are numbered [0, 1, 2, …., N-1] and i-th friend have a positive strength S(i). Today being his birthday, his friends have planned to give him birthday bombs (kicks :P). Tushar’s friends know Tushar’s pain bearing limit and would hit accordingly.
        //    If Tushar’s resistance is denoted by R (>=0) then find the lexicographically smallest order of friends to kick Tushar so that the cumulative kick strength(sum of the strengths of friends who kicks) doesn’t exceed his resistance capacity and total no.of kicks hit are maximum. Also note that each friend can kick unlimited number of times (If a friend hits x times, his strength will be counted x times)

        //Note:

        //Answer format = Vector of indexes of friends in the order in which they will hit.
        //    Answer should have the maximum no.of kicks that can be possibly hit.If two answer have the same no.of kicks, return one with the lexicographically smaller.
        //[a1, a2, …., am] is lexicographically smaller than[b1, b2, .., bm] if a1<b1 or (a1 = b1 and a2 < b2) … .
        //Input cases are such that the length of the answer does not exceed 100000.
        //Example:
        //R = 11, S = [6,8,5,4,7]

        //ans = [0,2]
        //Here, [2,3], [2,2] or[3, 3] also give the maximum no.kicks.

        private List<int> SortAndRemoveDuplicated(List<int> A, out Dictionary<int, int> dict)
        {
            dict = new Dictionary<int, int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (!dict.ContainsKey(A[i]))
                {
                    dict.Add(A[i], i);
                }
            }

            var array = dict.Keys.ToList();
            array.Sort();
            return array;
        }

        List<int> GetMaxKicks(int R, List<int> A, int index, Dictionary<int, int> indexDict, int minKicks)
        {
            if (R <= 0 || minKicks <= 0 || index >= A.Count)
            {
                return new List<int>();
            }

            var kickCapacity = R / A[index];

            if (kickCapacity < minKicks)
            {
                return new List<int>();
            }

            var rs = new List<int>();

            for (var i = kickCapacity; i >= 0; i--)
            {
                var RNew = R - A[index] * i;
                var minKicksNew = kickCapacity - i;
                var nextList = GetMaxKicks(RNew, A, index + 1, indexDict, minKicksNew);

                var insertIndex = 0;

                while (insertIndex < nextList.Count && indexDict[A[index]] > nextList[insertIndex])
                {
                    insertIndex++;
                }

                for (int j = 0; j < i; j++)
                {
                    nextList.Insert(insertIndex, indexDict[A[index]]);
                }

                if (nextList.Count > rs.Count)
                {
                    rs = new List<int>(nextList);
                }
                else if (nextList.Count == rs.Count)
                {
                    var isBetter = true;

                    for (int k = 0; k < nextList.Count; k++)
                    {
                        if (nextList[k] < rs[k])
                        {
                            break;
                        }

                        if (nextList[k] > rs[k])
                        {
                            isBetter = false;
                            break;
                        }
                    }

                    if (isBetter)
                    {
                        rs = new List<int>(nextList);
                    }
                }
                else
                {
                    return rs;
                }
            }

            return rs;
        }

        public List<int> solve(int A, List<int> B)
        {
            if (A == 0 || B.Count == 0)
            {
                return new List<int>();
            }

            Dictionary<int, int> indexDict;
            var sortedArray = SortAndRemoveDuplicated(B, out indexDict);

            return GetMaxKicks(A, sortedArray, 0, indexDict, 1);
        }
    }
}





