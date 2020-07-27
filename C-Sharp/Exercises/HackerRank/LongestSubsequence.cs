using System;

namespace HackerRank
{
    public static class LongestSubsequence
    {
        public static string GetLongestSubsequence(string s1, string s2)
        {
            if (s1 == null || s2 == null) throw new System.ArgumentNullException();
            if (s1.Length == 0 || s2.Length == 0) return string.Empty;

            int[][] memo = new int[s1.Length+1][];
            for (int i = 0; i <= s1.Length; i++)
            {
                memo[i] = new int[s2.Length+1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    memo[i][j] = s1[i-1] == s2[j-1] ?
                        1 + memo[i - 1][j - 1] :
                        Math.Max(memo[i - 1][j], memo[i][j - 1]);
                }
            }


            return getStringFromMemo(s1, s2, memo);
        }

        private static string getStringFromMemo(string s1, string s2, int[][] memo)
        {
            int i = s1.Length;
            int j = s2.Length;

            char[] result = new Char[memo[i][j]];
            int index = result.Length - 1;

            while (index >= 0)
            {
                if (memo[i][j] != memo[i][j - 1] && memo[i][j] != memo[i - 1][j])
                {
                    result[index--] = s1[i - 1];
                    i--;
                    j--;
                }
                else if (memo[i][j] == memo[i - 1][j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            return new string(result);
        }

    }
}