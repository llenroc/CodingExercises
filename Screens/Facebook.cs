using System.Collections.Generic;

namespace InterviewCake
{
    public class Facebook
    {
        public static void GetMinContainingLengthTest()
        {
            System.Console.WriteLine(GetMinContainingLength("cba", "aaccccbbbbcccaac"));
            System.Console.WriteLine(GetMinContainingLength("cba", "fcbccaacceabm"));
            System.Console.WriteLine(GetMinContainingLength("cba", "abc"));
        }

        /* 
        given a CharSet and a String,
        return the Leng of the smallest substraing which contains the chars in the Charset
        input: "cba", "cbccaaccab"
        out: 3
        Explanation: the substring from the last 3 chars is the smallest substring which contains the chars in the charset
        */
        public static int GetMinContainingLength(string charSet, string s)
        {
            if (charSet == null || charSet.Length == 0) return 0;
            if (s == null || s.Length == 0) return -1; // OR ...throw new System.InvalisArgumentException();

            var freqTable = new Dictionary<char, int>();
            foreach (var c in charSet) freqTable.Add(c, 0);

            var result = -1;
            var i = -1;
            for (var ini = 0; ini <= s.Length - charSet.Length; ini++)
            {
                var c = s[ini];
                if (freqTable.ContainsKey(c))
                {
                    freqTable[c]++;
                    i = ini;
                    break;
                }
            }
            if (i == -1) return -1;

            var j = i + 1;
            for (; i <= s.Length - charSet.Length; i++)
            {
                var c = s[i];
                for (; j < s.Length; j++)
                {
                    var cc = s[j];
                    if (freqTable.ContainsKey(cc)) freqTable[cc]++;

                    if (IsValidSubstring(freqTable))
                    {
                        if (result == -1 || result > j - i) result = j - i + 1;

                        // decrease the freq counter
                        if (freqTable.ContainsKey(c)) freqTable[c]--;
                        if (freqTable.ContainsKey(cc)) freqTable[cc]--;
                        
                        break;
                    }
                }
            }
            return result;
        }

        private static bool IsValidSubstring(Dictionary<char, int> freqTable)
        {
            foreach (var item in freqTable) 
            {
                if (item.Value == 0) return false;
            }
            return true;
        }
    }
}
