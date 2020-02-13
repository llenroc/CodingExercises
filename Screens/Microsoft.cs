using System;

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
}