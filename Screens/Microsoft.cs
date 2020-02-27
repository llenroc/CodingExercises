using System;
using System.Collections.Generic;

public static class Microsoft
{
    public static void GetDicLowestStringTest()
    {
        System.Console.WriteLine(GetDicLowestString("z"));
        System.Console.WriteLine(GetDicLowestString("abc"));
        System.Console.WriteLine(GetDicLowestString("9999"));
        System.Console.WriteLine(GetDicLowestString("cody"));
    }

    /*
    Function that receives a string and returns the lowest string posible by removing ONLY 1 Char
    lowest menas the string that will be found first in a English Dictionary, i.e.:

    input: cody
        posible strings: ody, cdy, coy, cod
    out: cod

    explanation: if those were sorted, the lowest (first in the dictionary) will be "cdy"
    */
    public static string GetDicLowestString(string input)
    {
        if (input == null) throw new System.ArgumentException("Input can not be null");
        if (input.Length == 0) throw new System.ArgumentException("Input can not be empty");
        for (var i = 0; i < input.Length - 1; i++)
        {
            if (input[i] > input[i + 1]) return input.Substring(0, i) + input.Substring(i + 1);
        }
        return input.Substring(0, input.Length - 1);
    }

    public static void GetWordsTest()
    {
        var result = GetWords("mississippi", 4);
        foreach (var item in result)
        {
            System.Console.WriteLine(item);
        }
    }

    // Given a string (ex: legend) and a substring length of x (ex: 4)
    // return a list of the unique substrings in the word where a character appears
    // more than one time.
    // solution for legend: lege, egen
    // solution for mississippi: miss, issi, ssis, siss, ssip, sipp, ippi

    public static List<string> GetWords(string w, int len)
    {
        // TODO: validate input
        var result = new HashSet<string>();
        var freq = new Dictionary<char, int>();
        var ini = 0;
        for (var runner = 0; runner < w.Length; runner++)
        {
            var c = w[runner];
            if (!freq.ContainsKey(c))
                freq.Add(c, 1);
            else
                freq[c]++;

            if (runner < len - 1) continue;
            
            for (var i = ini; i <= runner; i++)
            {
                if (freq[w[i]] > 1) result.Add(w.Substring(ini, len));
            }
            freq[w[ini++]]--; // Sliding to right
        }   
        return new List<string>(result);
    }

    public static void MicrosoftTest()
    {
        Console.WriteLine(MicrosoftOnlineTest(new [] {1,1,3,3}, 2));
    }

    // Change only one line to produce the correct result
    public static bool MicrosoftOnlineTest(int[] A, int K) 
    {
        int n = A.Length;
        for (int i = 0; i < n - 1; i++) {
            if (A[i] > K || A[i] != K) // change this line accordingly
                return false;
        }
        if (K < A[0] && A[n - 1] < K) // change this line accordingly
            return false;
        else
            return true;
    }
}