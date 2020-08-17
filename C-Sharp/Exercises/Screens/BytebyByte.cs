using System;

namespace Screens
{
    /* Byte by Byte - DP Exercises: https://www.byte-by-byte.com/6-dynamic-programming-questions */
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

        public static void GetBigestSquareSubmatrixTest()
        {
            var matrix = new [] {
                new [] {0,1,1,0},
                new [] {1,1,0,1},
                new [] {0,0,1,1},
                new [] {1,1,1,0}
            };
            System.Console.WriteLine("Biggest square size: " + GetBigestSquareSubmatrix(matrix));
        }

        // Given a 2D array of 1s and 0s, find the largest square subarray of all 1s
        public static int GetBigestSquareSubmatrix(int[][] matrix)
        {
            var result = 0;
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            
            var memo = new int[rows][];
            for (var r = 0; r < rows; r++)  memo[r] = new int[cols];

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == 1)
                    {
                        memo[r][c] = (c == 0 || r == 0) ? 1 : Math.Min(memo[r - 1][c - 1], Math.Min(memo[r][c - 1], memo[r - 1][c])) + 1;
                    }
                    if (result < memo[r][c]) result = memo[r][c];
                }
            }
            return result;
        }

        public static void GetMaxtrixProductTest()
        {
            var matrix = new [] {
                new [] {-1, 2, 3},
                new [] { 4, 5,-6},
                new [] { 7, 8, 9}
            };
            System.Console.WriteLine("Biggest Matrix Product: " + GetMaxtrixProduct(matrix));
        }

        /* Given a matrix, find the path from top left to bottom right with the greatest product by moving only down and right. */
        public static int GetMaxtrixProduct(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            
            var memoMin = new int[rows][];
            var memoMax = new int[rows][];
            for (var r = 0; r < rows; r++)  
            {
                memoMin[r] = new int[cols];
                memoMax[r] = new int[cols];
            }
            memoMin[0][0] = matrix[0][0];
            memoMax[0][0] = matrix[0][0];

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    if (r == 0 && c == 0) continue;

                    var min = int.MaxValue;
                    var max = int.MinValue;
                    if (r > 0)
                    {
                        var tmpMax = Math.Max(matrix[r][c] * memoMax[r - 1][c], matrix[r][c] * memoMin[r - 1][c]);
                        max = Math.Max(tmpMax, max);
                        
                        var tmpMin = Math.Min(matrix[r][c] * memoMin[r - 1][c], matrix[r][c] * memoMax[r - 1][c]);
                        min = Math.Min(tmpMin, min);
                    }
                    if (c > 0)
                    {
                        var tmpMax = Math.Max(matrix[r][c] * memoMax[r][c - 1], matrix[r][c] * memoMin[r][c - 1]);
                        max = Math.Max(tmpMax, max);
                        
                        var tmpMin = Math.Min(matrix[r][c] * memoMin[r][c - 1], matrix[r][c] * memoMax[r][c - 1]);
                        min = Math.Min(tmpMin, min);
                    }
                    memoMax[r][c] = max;
                    memoMin[r][c] = min;
                }
            }
            return memoMax[rows-1][cols-1];        
        }

        public static int Knapsack(Item[] items, int maxWeigth)
        {
            int[] memo = new int[maxWeigth + 1];
            foreach (Item item in items)
            {
                for (int i = 0; i <= maxWeigth; i++)
                {
                    if (i < item.Value) continue;
                    memo[i] = Math.Max(memo[i], (memo[i - item.Value] + item.Value));
                }
            }
            return memo[maxWeigth];
        }


    }

    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }

        public Item(int w, int v)
        {
            Weight = w;
            Value = v;
        }
    }
}