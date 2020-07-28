using System;
using System.Collections.Generic;

public class Niantic
{
    // Given a nested list of integers,
    // return the sum of all integers in the list weighted by the depth
    public static int GetSum(NestedValue nestedValue, int depth)
    {
        if (nestedValue.IsInteger) return nestedValue.Item * depth;

        int sum = 0;
        foreach (NestedValue n in nestedValue.Items) sum += GetSum(n, depth + 1);

        return sum;
    }
}


public class NestedValue
{
    public int Item;
    public List<NestedValue> Items;

    public bool IsInteger
    {
        get
        {
            return Items == null;
        }
    }

    public NestedValue()
    {
        Items = new List<NestedValue>();
    }

    public NestedValue(int item)
    {
        Item = item;
    }

    public void Add(NestedValue item)
    {
        Items.Add(item);
    }
}