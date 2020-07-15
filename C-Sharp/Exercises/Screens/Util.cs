using System;
using System.Collections.Generic;

public static class Util
{
    public static HashSet<string> GetCombos(this string s)
    {
        HashSet<string> result = new HashSet<string>();
        double count = Math.Pow(2, s.Length); // Total number of Combinations

        for (int i = 1; i < count; i++)
        {
            string tmp = "";
            for (int j = 0; j < s.Length; j++)
            {
                int b = i & (1 << j);
                if (b > 0)
                {
                    tmp += s[j];
                }
            }
            result.Add(tmp);
        }
        return result;
    }

    public static HashSet<string> GetPermutations(this string s)
    {
        if (s.Length <= 1) return new HashSet<string>() { s }; 

        HashSet<string> result = new HashSet<string>();

        // get firts char and remainder
        char c = s[0];
        string remainder = s.Substring(1);

        // call permute using remainder (asign to words)
        HashSet<string> words = remainder.GetPermutations();

        // for each w in words
        foreach (string w in words)
        {
            // for each char in w, create the string using the index to get substrings: Before and After
            for (int i = 0; i <= w.Length; i++)
            {
                string before = w.Substring(0, i);
                string after = w.Substring(i);
                
                result.Add(new String(before + c + after));
            }
        }
            
        return result;
    }
}