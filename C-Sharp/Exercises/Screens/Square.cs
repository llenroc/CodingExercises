using System;
using System.Collections.Generic;

public class Square
{
    public static Dictionary<string, Object> BuildDic(string[] input1, int[] input2)
    {
        Dictionary<string, Object> result = new Dictionary<string, Object>();
        for (int i = 0; i < input1.Length; i++)
        {
            var entry = getEntry(input1[i].Split('.'), input2[i]);
            result.Add(entry.Key, entry.Value);
        }
        return result;
    }

    private static KeyValuePair<string, Object> getEntry(string[] props, int propValue)
    {
        Object previousVal = propValue;
        
        for (int i = props.Length - 1; i > 0; i--)
            previousVal = new KeyValuePair<string, Object>(props[i], previousVal);
        
        return new KeyValuePair<string, Object>(props[0], previousVal);
    }
}