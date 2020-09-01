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

    public static List<List<string>> GetWordsCombos(this List<string> s)
    {
        List<List<string>> permutations = s.GetWordsPermutations();

        HashSet<List<string>> combos = new HashSet<List<string>>();
        for (int i = 0; i < s.Count - 1; i++)
        {
            foreach (var words in permutations)
            {
                var tmp = new List<string>();
                for (var j = 0; j <= i && j < words.Count; j++) tmp.Add(words[j]);

                if (!combos.Contains(tmp)) combos.Add(tmp);
            }
        }

        foreach (var item in combos) permutations.Add(item);
        return permutations;
    }


    public static List<List<string>> GetWordsPermutations(this List<string> s)
    {
        if (s.Count <= 1)
        {
            var tmp = new List<string>(s);
            var x = new List<List<string>>(); 
            x.Add(tmp);
            return x;
        }

        List<List<string>> result = new List<List<string>>();

        // get firts char and remainder
        string c = s[0];
        List<string> remainder = new List<string>();
        for (int i = 1; i < s.Count; i++) remainder.Add(s[i]);

        // call permute using remainder (asign to words)
        List<List<string>> words = remainder.GetWordsPermutations();

        // for each w in words
        foreach (List<string> w in words)
        {
            string[] stringArray = w.ToArray();
            // for each char in w, create the string using the index to get substrings: Before and After
            for (int i = 0; i <= stringArray.Length; i++)
            {

                List<string> before = new List<string>();
                for (int ini = 0; ini < i; ini++) before.Add(stringArray[ini]);

                List<string> after = new List<string>();
                for (int ini = i; ini < stringArray.Length; ini++) after.Add(stringArray[ini]);
                
                List<string> tmp = new List<string>();
                foreach (var item in before) tmp.Add(item);
                tmp.Add(c);
                foreach (var item in after) tmp.Add(item);

                result.Add(tmp);
            }
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