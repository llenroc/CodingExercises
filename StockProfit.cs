using System;
public class StockProfit
{
	public static int GetMaxProfit(int[] n)
	{
		if (n == null || n.Length < 2) throw new ArgumentException("Input must have at least 2 values");
		
		var lowest = n[0];
		var maxProfit = n[1] - lowest;
		for (var i = 1; i < n.Length; i++)
		{
			var curr = n[i];
			maxProfit = Math.Max(maxProfit, curr - lowest);
			lowest = Math.Min(curr, lowest);
		}
		return maxProfit;
	}
	
    public static void GetMaxProfitTest()
	{
        Console.WriteLine("Min Negative Profit: " + GetMaxProfit(new [] { 10, 7, 1}));
        Console.WriteLine("No Profit: " + GetMaxProfit(new [] { 10, 10, 10, 10}));
        Console.WriteLine("Max Profit: " + GetMaxProfit(new [] { 10, 7, 5, 8, 11, 9 }));
    }
 }