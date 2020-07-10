using System;
using System.Collections.Generic;

namespace Exercises
{
    public class Facebook
    {
        public static void GetMinContainingLengthTest()
        {
            System.Console.WriteLine(GetMinContainingLength("cba", "baacccac")); // -1
            //System.Console.WriteLine(GetMinContainingLength("cba", "fccbcbcacaccbxbabm")); // 4
            //System.Console.WriteLine(GetMinContainingLength("cba", "cba")); // 3
        }

        /* 
        given a CharSet and a String,
        return the Leng of the smallest substring which contains the chars in the Charset in order (c, then b, then a)
        input: "cba", "acbcbbcaaccbab"
        out: 3
        Explanation: Some the substring are candidates: cbcbbcaaccba, cbbcaaccba, caaccba, ccba, cba
         The las one is the smallest (3 chars) substring which contains the chars in the charset
        */
        public static int GetMinContainingLength(string charSet, string s)
        {
            if (charSet == null || charSet.Length == 0) return 0;
            if (s == null || s.Length == 0) return -1; // OR ...throw new System.InvalisArgumentException();

            return GetMinContainingLength(charSet, s, 0, -1);
        }

        private static int GetMinContainingLength(string charSet, string s, int ini, int result)
        {
            if (s.Length - ini < charSet.Length) return result;

            var i = 0; // charset index
            for (var j = ini; j < s.Length; j++)
            {
                if (charSet[i] != s[j]) continue;
                if (i == charSet.Length - 1)
                {
                    result = UpdateSlidingFromLeft(j, ini, s, charSet);
                    return Math.Min(result, GetMinContainingLength(charSet, s, j + 1, result));
                }
                i++;
            }
            return -1;
        }

        private static int UpdateSlidingFromLeft(int j, int ini, string s, string charSet)
        {
            var result = j - ini + 1;
            for (var i = ini + 1; i <= j; i++)
            {
                var tmp = j - i + 1;
                if (!IsStillValid(j, i, s, charSet)) return result;
                result = tmp;
            }
            return result;
        }

        private static bool IsStillValid(int j, int ini, string s, string charSet)
        {
            var indexCharSet = 0;
            for (var i = ini; i <= j; i++)
            {
                if (charSet[indexCharSet] != s[i]) continue;
                if (indexCharSet == charSet.Length - 1) return true;
                indexCharSet++;
            }
            return false;
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
}
