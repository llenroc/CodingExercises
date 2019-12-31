using System;

public class HighestTripletPruduct
{

    public static int GetHighestTripletPruduct(int[] n)
    {
        // 
        if (n == null || n.Length < 2)
        {
            throw new ArgumentException("input mush have at least 3 elements");
        }

        // init
        var h3p = n[0] * n[1] * n[2];
        var h = Math.Max(n[0], n[1]);
        var l = Math.Min(n[0], n[1]);
        var h2 = n[0] * n[1];
        var l2 = n[0] * n[1];

        for (var i = 2; i < n.Length; i++)
        {
            var curr = n[i];

            h3p = Math.Max(h3p, Math.Max(h2 * curr,l2 * curr));
            h2 = Math.Max(h2, Math.Max(h * curr, l * curr));
            l2 = Math.Min(l2, Math.Min(h * curr, l * curr));
            h = Math.Max(h, curr);
            l = Math.Min(l, curr);
        }

        return h3p;
    }

    public static void GetHighestTripletPruductTest()
    {
        Console.WriteLine(GetHighestTripletPruduct(new [] {1, 10, -5, 1, -100}));
    }
}