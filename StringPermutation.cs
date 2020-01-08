using System;
using System.Collections.Generic;

namespace InterviewCake
{
    public static class StringPermutation
    {
        public static void GetPermutationsTest()
        {
            var result = GetPermutations("input");

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static HashSet<string> GetPermutations(String inputString)
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

        private static HashSet<string> Permute(string s, int ini, int end, HashSet<string> result)
        {
            if (ini == end)
            {
                result.Add(s);
            }
        
            for (int i = ini; i <= end; i++)
            {
                s = Swap(s, ini, i);
                result = Permute(s, ini + 1, end, result);
                s = Swap(s, ini, i);
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