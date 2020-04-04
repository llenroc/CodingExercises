using System;
using System.Collections;
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

    #region "1st OnLine Assesment"
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
        var combos = GetPowerSet(A);
        var result = 0;
        foreach (var c in combos) result = Math.Max(result, c.Length);
        return result;
    }

    /* PowerSer -> Good explication here: https://coderbyte.com/algorithm/print-all-subsets-given-set */
    public static List<string> GetPowerSet(string[] A) 
    { 
        var result = new List<string>();
        /*set_size of power set of a set with set_size n is (2**n -1) beacuse we will be trating the items a binary*/
        var powSize = (uint)Math.Pow(2, A.Length); 
        
        /*Run from counter 000..0 to 111..1*/
        for(var i = 0; i < powSize; i++) 
        { 
            var tmp = string.Empty;
            for(var j = 0; j < A.Length; j++) 
            { 
                /* Check if jth bit in the counter is set. If set then add jth element from set */
                if((i & (1 << j)) > 0) tmp += A[j]; 
            }
            if (IsValid(tmp)) result.Add(tmp);
        }
        return result;
    } 

    // Specific rule for this exercise
    private static bool IsValid(string s)
    {
        if (s == null || s.Length == 0) return false;
        var hs = new HashSet<char>();
        foreach (var c in s)
        {
            if (hs.Contains(c)) return false;
            hs.Add(c);
        }
        return true;
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


    #region "2nd OnLine Assesment"

    public static void OnLineTest()
    {
        // var input = new [] {1,2};
        // var result = Exercise(2, 4);
        // foreach (var item in result)
        // {
        //     System.Console.WriteLine(item);
        // }
        
        // var input = new [] {5,5,5,5,5};
        // var result = Exercise2(input);
        // System.Console.WriteLine(result);

        //System.Console.WriteLine(Exercise3(670));
        System.Console.WriteLine(Exercise3(-999));
        //System.Console.WriteLine(Exercise3(0));
    }

    public static string[] Exercise(int N, int K)
    {
        if (N == 0) {
            return new string[] {""};
        }
        var result = new List<String>();
        foreach (string p in Exercise(N - 1, K - 1)) {
            foreach (char l in new char[] {'a', 'b', 'c'}) {
                int pLen = p.Length;
                if (pLen == 0 || p[pLen - 1] != l) {
                    result.Add(p + l);
                }
            }
        }
        int prefSize = Math.Min(result.Count, K);
        return result.GetRange(0, prefSize).ToArray();
    }

    public static int Exercise2(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        if (A == null) throw new System.Exception("Null input parameter");
        if (A.Length < 1) return 0;
        
        var freqTable = new Dictionary<int, int>();
        foreach (var n in A)
        {
            if (!freqTable.ContainsKey(n)) freqTable.Add(n,0);
            freqTable[n]++;
        }
        
        var result = 0;
        foreach (var entry in freqTable)
        {
            if (entry.Key == entry.Value) result = Math.Max(result, entry.Value);
        }
        return result;
    }


    public static int Exercise3(int N) {
        var isNegative = (N < 0);
        var input = (isNegative) ? (N * -1).ToString() : N.ToString();
        
        var result = String.Empty;
        for (var i = input.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                result = "5" + input;
            }
            else
            {
                if (int.Parse(input[i].ToString()) < 5 && int.Parse(input[i - 1].ToString()) > 5)
                {
                    result = input.Substring(0, i) + "5" + input[i].ToString() + result;
                    break;
                }
                else
                {
                    result = input[i].ToString() + result;
                }
            }
        }

        var res = int.Parse(result);
        return (isNegative) ? res *= -1 : res;
    }

    #endregion
}