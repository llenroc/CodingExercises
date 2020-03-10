using System;

namespace InterviewCake
{
    public class BytebyByte
    {
        public static void GetSmalestChangeTest()
        {
            //var result = GetNumberOfCoinCombos(new [] { 3, 1, 5, 2 }, 10);
            var result = GetSmalestChange(new [] { 3, 1, 5, 2 }, 5);
            System.Console.WriteLine("Min number of coins: " + result);
        }

        public static int GetSmalestChange(int[] coins, int amount)
        {
            var amounts = new int[amount + 1]; // cache or memoization
            for (var amt = 1; amt <= amount; amt++)
            {
                amounts[amt] = int.MaxValue;
            }
            amounts[0] = 0; // base case

            foreach (var c in coins)
            {
                for (var amt = 1; amt <= amount; amt++)
                {
                    if (amt >= c && amounts[amt-c] != int.MaxValue) amounts[amt] = Math.Min(amounts[amt-c] + 1, amounts[amt]);
                }
            }

            return amounts[amount];
        }

        public static void GetLongestCommonSubstringTest()
        {
            // var result = GetLongestCommonSubstring("ABAB", "BABA");
            var result = GetLongestCommonSubstring("PEREZ HERNANDEZ", "MENDEZ ORDONEZ");
            System.Console.WriteLine("Longest Substring Length: " + result);
        }

        public static int GetLongestCommonSubstring(string a, string b)
        {
            var memo = new int[a.Length];

            foreach (var c in b)
            {
                for (var i = 0; i < a.Length; i++)
                {
                    if (c == a[i])
                    {
                        memo[i] = (i != 0) ? memo[i - 1] + 1 : 1;
                    }
                }
            }

            return memo[a.Length - 1];
        }

        public static void FibonacciTest()
        {
            var n = 5;
            System.Console.WriteLine(String.Format("Fibonacci de {0}: {1}", n, Fibonacci(n)));
        }

        public static long Fibonacci(int n)
        {
            if (n < 0) return -1; // invalid
            if (n == 0) return 0; 

            var memo = new long[n + 1];
            memo[1] = 1; // base case (memo[0] is initialized as Zero when the array is created)
            for (var i = 2; i < memo.Length; i++)
            {
                memo[i] = -1;
            }

            return GetFibonacci(n, memo);
        }

        private static long GetFibonacci(int n, long[] memo)
        {
            if (memo[n] != -1) return memo[n];

            memo[n] = GetFibonacci(n - 1, memo) + GetFibonacci(n - 2, memo);
            
            return memo[n];
        }
    }
}