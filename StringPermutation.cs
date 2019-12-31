using System;
using System.Collections.Generic;

namespace Exercises
{
    public static class StringPermutation
    {
        public static ISet<string> GetPermutations(String inputString)
        {
            // Generate all permutations of the input string
            HashSet<string> result = new HashSet<string>();
        
            if (String.IsNullOrEmpty(inputString))
            {
                result.Add(inputString);
            }
            else
            {
                result = Permute(inputString, 0, inputString.Length - 1, result);
            }
        
            return result;
        }

        private static HashSet<string> Permute(string s, int l, int r, HashSet<string> result)
        {
            if (l == r)
            {
                result.Add(s);
            }
        
            for (int i = l; i <= r; i++)
            {
                s = Swap(s, l, i);
                result = Permute(s, l + 1, r, result);
                s = Swap(s, l, i);
            }
            return result;
        }

        private static string Swap(string s, int i, int j)
        {
            char[] charArray = s.ToCharArray();
            char tmp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = tmp;
            return new string(charArray);
        }
    }
}