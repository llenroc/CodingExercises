using System;
using System.Collections.Generic;

public class Honey
{

    public static bool IsValid(string input)
    {
        if (input == null) throw new System.ArgumentNullException();
        if (input.Length == 0) return true;
        if (input.Length == 1) return input[0] == '*';

        char[] s = new char[input.Length];
        s[0] = input[0];

        return IsValid(input, s, 0);
    }

    private static bool IsValid(string input, char[] s, int index)
    {
        if (index == input.Length - 1) return IsValid(s);

        index++;
        if (input[index] != '*')
        {
            s[index] = input[index];
            return IsValid(input, s, index);
        }
        else
        {
            s[index] = '_';
            bool optionA = IsValid(input, s, index);
            if (!optionA)
            {
                s[index] = '[';
                bool optionB = IsValid(input, s, index);
                if (!optionB)
                {
                    s[index] = ']';
                    return IsValid(input, s, index);
                }
            }
            return true;
        }
    }

    public static bool IsValid(char[] s)
    {
        Stack<char> stk = new Stack<char>();

        foreach(char c in s)
        {
            if (c == '_') continue;

            if (c == '[')
                stk.Push(c);
            else
                if (stk.Count == 0 || stk.Pop() != '[') return false;
        }

        return stk.Count == 0;
    }


}