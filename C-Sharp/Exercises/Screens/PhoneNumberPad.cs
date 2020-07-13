using System;
using System.Collections.Generic;

public static class PhoneNumberPad
{

    private static string[] pad =  {
        // 1      2       3
        "",     "abc",  "def",

        // 4      5       6 
        "ghi",  "jkl",  "mno",

        // 7      8       9
        "pqrs", "tuv",  "wxyz" };

    public static List<string> GetAllCombos(int[] digits)
    {
        if (digits == null) throw new System.ArgumentNullException();
        
        List<string> result = new List<string>();
        
        if (digits.Length == 0) return result;

        Queue<string> q = new Queue<string>();
        q.Enqueue("");

        while (q.Count > 0)
        {
            string candidate = q.Dequeue();
            if (candidate.Length == digits.Length)
            {
               result.Add(candidate);
            }
            else
            {
                char[] chars = pad[digits[candidate.Length]].ToCharArray();
                foreach (char c in chars)
                {
                    q.Enqueue(candidate + c);
                }
            }
        }

        return result;
    }
}