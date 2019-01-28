﻿using System;

namespace BitInterView
{
    public partial class Solution
    {
        //Regular Expression Match
        //implement wildcard pattern matching with support for '?' and '*'.

        //'?' : Matches any single character.
        //'*' : Matches any sequence of characters (including the empty sequence).
        //The matching should cover the entire input string (not partial).

        //The function prototype should be:
        //isMatch("aa","a") → 0
        //isMatch("aa","aa") → 1
        //isMatch("aaa","aa") → 0
        //isMatch("aa", "*") → 1
        //isMatch("aa", "a*") → 1
        //isMatch("ab", "?*") → 1
        //isMatch("aab", "c*a*b") → 0
        //a* a -> 0
        //a a* -> 1
        //a? a -> 0
        //a a? -> 0

        public int isMatch(string S, string P)
        {
            int sSize = S.Length; int pSize = P.Length;

            int star = -1;
            int prevStart = 0;
            int i = 0; int j = 0;

            while (i < sSize)
            {
                if (j < pSize && (S[i] == P[j] || P[j] == '?'))
                {
                    i++; j++;
                }
                else if (j < pSize && P[j] == '*')
                {
                    star = j++;
                    prevStart = i;
                }
                else if (star != -1)
                {
                    j = star + 1;
                    i = ++prevStart;
                }
                else return 0;
            }

            while (j < pSize && P[j] == '*')
                j++;

            return j == pSize ? 1 : 0;

        }

        //Implement regular expression matching with support for '.' and '*'.

        //'.' Matches any single character.
        //'*' Matches zero or more of the preceding element.

        //The matching should cover the entire input string (not partial).
        //isMatch("aa","a") → 0
        //isMatch("aa","aa") → 1
        //isMatch("aaa","aa") → 0
        //isMatch("aa", "a*") → 1
        //isMatch("aa", ".*") → 1
        //isMatch("ab", ".*") → 1
        //isMatch("aab", "c*a*b") → 1
        //        This looks just like a straight forward string matching, isn’t it? Couldn’t we just match the pattern and the input string character by character? The question is, how to match a '*' ?

        //A natural way is to use a greedy approach; that is, we attempt to match the previous character as many as we can.Does this work? Let us look at some examples.

        //s = “abbbc”
        //p = “ab* c”
        //Assume we have matched the first ‘a’ on both s and p.When we see "b*" in p, we skip all b’s in s.Since the last ‘c’ matches on both side, they both match.

        //s = “ac”
        //p = “ab* c”
        //After the first ‘a’, we see that there is no b’s to skip for “b*”. We match the last ‘c’ on both side and conclude that they both match.

        //It seems that being greedy is good.But how about this case?

        //s = “abbc”
        //p = “ab* bbc”
        //When we see “b*” in p, we would have skip all b’s in s.They both should match, but we have no more b’s to match.Therefore, the greedy approach fails in the above case.

        //One might be tempted to think of a quick workaround. How about counting the number of consecutive b’s in s? If it is smaller or equal to the number of consecutive b’s after “b*” in p, we conclude they both match and continue from there. For the opposite, we conclude there is not a match.

        //This seem to solve the above problem, but how about this case:

        //s = “abcbcd” 
        //p = “a.* c.*d”
        //Here, “.*” in p means repeat ‘.’ 0 or more times.Since ‘.’ can match any character, it is not clear how many times ‘.’ should be repeated.Should the ‘c’ in p matches the first or second ‘c’ in s? Unfortunately, there is no way to tell without using some kind of exhaustive search.

        //We need some kind of backtracking mechanism such that when a matching fails, we return to the last successful matching state and attempt to match more characters in s with ‘*’. This approach leads naturally to recursion.


        //The recursion mainly breaks down elegantly to the following two cases:


        //If the next character of p is NOT ‘*’, then it must match the current character of s.Continue pattern matching with the next character of both s and p.
        //If the next character of p is ‘*’, then we do a brute force exhaustive matching of 0, 1, or more repeats of current character of p… Until we could not match any more characters.
        //You would need to consider the base case carefully too. That would be left as an exercise to the reader. :)
        public int isMatch1(string A, string B)
        {
            if (Match(A, B, 0, 0))
                return 1;

            return 0;
        }

        public bool Match(string A, string B, int indexA, int indexB)
        {
            if ((indexA >= A.Length) != (indexB >= B.Length))
                return false;

            if (indexA >= A.Length)
                return true;

            if (indexB == B.Length - 1)
                return (B[indexB] == '.' || A[indexA] == B[indexB]) && Match(A, B, indexA + 1, indexB + 1);

            if (B[indexB + 1] == '*')
            {
                for (; indexA < A.Length; indexA++)
                {
                    if (B[indexB] != '.' && A[indexA] != B[indexB])
                        return Match(A, B, indexA, indexB + 2);
                    if (Match(A, B, indexA, indexB + 2))
                        return true;
                }

                return indexB + 2 == B.Length;
            }
            else if (B[indexB] == '.')
            {
                return Match(A, B, indexA + 1, indexB + 1);
            }
            else
            {
                return A[indexA] == B[indexB] && Match(A, B, indexA + 1, indexB + 1);
            }
        }

        private bool isPanaStr(string A, string B)
        {
            if (A.Length != B.Length)
            {
                return false;
            }

            while (!string.IsNullOrEmpty(A))
            {
                var c = A[0];
                var index = B.IndexOf(c);

                if (index < 0)
                {
                    return false;
                }

                A = A.Remove(0, 1);
                B = B.Remove(index, 1);
            }

            if (B.Length > 0)
            {
                return false;
            }

            return true;
        }

        //private int isScramble(string A, string B, int startA, int endA, int startB, int endB)
        //{

        //}

        //Scramble String
        //https://www.interviewbit.com/problems/scramble-string/
        public int isScramble(string A, string B)
        {
            if (A == B)
            {
                return 1;
            }

            if (!isPanaStr(A, B))
            {
                return 0;
            }

            for (int i = 1; i < B.Length; i++)
            {
                var startA = A.Substring(0, i);
                var endA = A.Substring(i);
                var startB = B.Substring(0, i);
                var endB = B.Substring(i);

                if (isScramble(startA, startB) > 0 && isScramble(endA, endB) > 0)
                {
                    return 1;
                }

                if (isScramble(startA, B.Substring(B.Length - i)) > 0 && isScramble(endA, B.Substring(0, B.Length - i)) > 0)
                {
                    return 1;
                }
            }

            return 0;
        }

        public bool TooYoung { get; set; }

        private DateTime _DateSelected;
        public DateTime DateSelected
        {
            get { return _DateSelected; }
            set
            {
                if (_DateSelected.Equals(value))
                {
                    return;
                }

                _DateSelected = value;

                var age = CalculateAge(_DateSelected);
                TooYoung = age <= 15;
            }
        }

        private int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;

            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}
