using System;
using System.Collections.Generic;

public class Compass
{
    public static HashSet<string> myCustomDict = new HashSet<string>{
        "address",
        "the",
        "there",
        "they",
        "red",
        "run",
        "dress"
    };

    public static bool ContainsValidWords(string s)
    {
        string tmp = string.Empty;
        for (int i = 0; i < s.Length; i++)
        {
            if (!Compass.myCustomDict.Contains(tmp))
            {
                tmp += s[i];
                continue;
            }

            if (ContainsValidWords(s.Substring(i))) return true;
            
            tmp += s[i];
        }
        return myCustomDict.Contains(tmp);            
    }
}
