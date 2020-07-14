using System;
using System.Collections.Generic;

// Problem: https://www.hackerrank.com/challenges/the-power-sum/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
public static class ThePowerSum
{
    public static int PowerSum(int X, int N)
    {   
        int tmp = (int) Math.Pow(Double.Parse(X.ToString()), 1.0/N);
        var temp = new List<int>();
        for (int i = 1; i <= tmp; i++)
            temp.Add(i);
        return getCombos(temp, X, N).Count; //getValid(getCombos(temp, X, N), N, X).Count;
    }

    private static List<List<int>> getCombos(List<int> list, int X, int N)
    {
        List<List<int>> result = new List<List<int>>();
        double count = Math.Pow(2, list.Count); // Total number of Combinations

        for (int i = 1; i <= count - 1; i++)
        {
            List<int> tmp = new List<int>();
            double sum = 0;
            for (int j = 0; j < list.Count; j++)
            {
                int b = i & (1 << j);
                if (b > 0)
                {
                    tmp.Add(list[j]);
                    sum += Math.Pow(Double.Parse(list[j].ToString()), Double.Parse(N.ToString()));
                }
            }
            if (sum == X) result.Add(tmp);
        }

        return result;
    }

}