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

    #region "OnLine Assesment"
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

    /*
    Concatenation is an operation that joins strings i.e.: Smart + phone = Smartphone
    Concatenation can be expanded to +2 strings, i.e.: Do + min + go = Domingo
    Problem: Givin an array os strings A, write a function that calculates the length of the longest string S such that:
    - S is a concatenationof some string offrom A
    - Every letter in S is different (no Dupes)
    Return ZERO if no contiditions are met
    */
    public static int GetLongestConcat(string[] A)
    {
        return 0;
    }

    public static void GetLongestConcatTest()
    {
        var A = new string[] { "this", "is", "a", "test" };
        System.Console.WriteLine("GetLongestConcat: " + GetLongestConcat(A));
    }

    /*
    Given two int arrays A and B and an integer N, where A[i] and B[i] are cities at the two ends of the i-th road,
    create a function that returns the maximal network rank in the whole infrastructure
    
    Example:
    A = [1, 2, 3, 3] 
    B = [2, 3, 1, 4]

    1
    | \
    |   3 - 4
    | /
    2

    Result: [2, 3]
    Explanation: The chosen cities may be 2 and 3, and the 4 roads connected to them are: (2, 1), (2, 3), (3,1), (3, 4) 

    Approach: Use a Dictionary (Time/Space: O(n))

    City (int)| Cities (Set<int>) | Size
    
    1st Example
    1           2, 3                2
    2           1, 3                2
    3           2, 1, 4             3
    4           3                   1

    2n example
    1           2                   1
    2           1, 3                2
    3           2                   1
    4           5                   1
    5           4, 6                2
    6           5                   1
    */
    public static int GetMaximalNetworkRank(int[] A, int[] B, int N)
    {
        var map = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < A.Length; i++)
        {
            if (!map.ContainsKey(A[i])) map.Add(A[i], new HashSet<int>());
            map[A[i]].Add(B[i]);
            if (!map.ContainsKey(B[i])) map.Add(B[i], new HashSet<int>());
            map[B[i]].Add(A[i]);
        }
        var result = 0;
        for (var i = 0; i < A.Length; i++)
        {
            var tmp = map[A[i]].Count + map[B[i]].Count - 1;
            result = Math.Max(result, tmp);
        }
        return result;
    }

    public static void GetMaximalNetworkRankTest()
    {
        // var A = new int[] {1, 2, 3, 3}; 
        // var B = new int[] {2, 3, 1, 4};
        // var result = GetMaximalNetworkRank(A, B, 4); // 2, 3
        var A = new int[] {1, 2, 4, 5}; 
        var B = new int[] {2, 3, 5, 6};
        var result = GetMaximalNetworkRank(A, B, 6); // 1, 2

        System.Console.WriteLine("Maximal Network Rank: " + result);
    }

    #endregion
}