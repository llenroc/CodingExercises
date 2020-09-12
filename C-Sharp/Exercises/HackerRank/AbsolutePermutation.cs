using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class AbsolutePermutation
    {
        public static int[] GetAbsolutePermutation(int n, int k)
        {
            int result = -1;

            string input = string.Empty;
            for (int i = 1; i <= n; i++) input += i.ToString();

            HashSet<string> permutations = input.GetPermutations();
            
            foreach (var p in permutations)
            {
                bool possible = false;
                for (int i = 0; i < p.Length; i++)
                {
                    if (Math.Abs(p[i] - input[i]) != k) break;
                    if (i == p.Length - 1) possible = true;
                }
                if (result == -1 && possible) result = Int16.Parse(p);
                if (possible) result = Math.Min(result, Int16.Parse(p));
            }
            
            if (result != -1)
            {
                string strResult = result.ToString();
                int[] r = new int[n];
                for (int i = 0; i < r.Length; i++) r[i] = int.Parse(strResult[i].ToString());
                
                return r;
            }
            else
            {
                return new int[] { -1 };
            }
        }
    }
}
