using System;
using System.Collections.Generic;

public static class Facebook
{
    
    /* 
    given a CharSet and a String,
    return the Leng of the smallest substring which contains the chars in the Charset in order (c, then b, then a)
    input: "cba", "acbcbbcaaccbab"
    out: 3
    Explanation: Some the substring are candidates: cbcbbcaaccba, cbbcaaccba, caaccba, ccba, cba
        The las one is the smallest (3 chars) substring which contains the chars in the charset
    */
    public static string GetMinString(string s, string chars)
    {
        int i = 0;
        string result = string.Empty;
        int ini = -1;
        int end = -1;
        
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (var c in chars)
        {
            if (!freq.ContainsKey(c))
            {
                freq.Add(c, 0);
            }
            freq[c]++;
        }


        Dictionary<char, int> current = new Dictionary<char, int>();
        for (int runner = 0; runner < s.Length; runner++)
        {
            char c = s[runner];
            if (!current.ContainsKey(c))
            {
                current.Add(c, 0);
            }
            current[c]++;

            if (runner < chars.Length - 1)
            {
                continue;
            }

            while (isCurrentValid(freq, current))
            {
                if (ini == -1 || runner - i < result.Length - 1 )
                {
                    ini = i;
                    end = runner;
                    result = s.Substring(ini, (end - ini) + 1);
                    
                    if (result.Length == chars.Length)
                    {
                        return result;
                    }
                }

                char leftSideChar = s[i];
                if (current.ContainsKey(leftSideChar))
                {
                    current[leftSideChar]--;
                }
                i++;
            }
        }

        return result;
    } 

    private static bool isCurrentValid(Dictionary<char, int> freq, Dictionary<char, int> current)
    {
        foreach (var c in freq)
        {
            if (!current.ContainsKey(c.Key) || current[c.Key] < c.Value)
            {
                return false;
            }
        }
        return true;
    }

    public static void WordDiccTest()
    {
        var dicc = new WordDicc();
        dicc.SetUp(new string[] {"a", "b", "c", "az", "hello", "boy", "come"});
        System.Console.WriteLine(dicc.Exists("boy"));   // T
        System.Console.WriteLine(dicc.Exists("al"));    // F
        System.Console.WriteLine(dicc.Exists("hell"));  // F
        System.Console.WriteLine(dicc.Exists("comer")); // F
    }

    public class WordDicc
    {
        public CustomNode Root { get; set; }

        public WordDicc()
        {
            Root = new CustomNode('\0', false);
            Root.Next = new Dictionary<char, CustomNode>();
        }

        public void SetUp(string[] words)
        {
            foreach (var w in words)
            {
                var curr = Root.Next;
                for (var i = 0; i < w.Length; i++)
                {
                    var c = w[i];
                    if (!curr.ContainsKey(c)) curr.Add(c, new CustomNode(c, i == w.Length - 1));
                    curr = curr[c].Next;
                }
            }
        }

        public bool Exists(string word)
        {
            var curr = Root.Next;
            for (var i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!curr.ContainsKey(c)) return false;   
                if (i == word.Length - 1) return curr[c].IsFinal;
                curr = curr[c].Next;
            }
            return false;
        }
    }

    public class CustomNode
    {
        public Char Value;
        public bool IsFinal;
        public Dictionary<char, CustomNode> Next; // could be a List<CustomNode> but I used Dictionary in order to have "constant time" lookups [O(1)]
        
        public CustomNode(Char c, bool isFinal)
        {
            Value = c; 
            Next = new Dictionary<char, CustomNode>();
            IsFinal = isFinal;
        }
    }    
}
