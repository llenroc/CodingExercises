using System;
using System.Collections.Generic;

namespace Exercises
{
    public static class DynamicProgramming
    {
        public static void MaxDuffelBagValueTest()
        {
            var cakes = new CakeType[] {
                new CakeType(2, 15),
                new CakeType(7, 160),
                new CakeType(3, 90)
            };

            System.Console.WriteLine(MaxDuffelBagValue(cakes, 20));
        }


        public static long MaxDuffelBagValue(CakeType[] cakes, int bagWeightCapacity)
        {
            var memo = new long[bagWeightCapacity + 1];

            for (var i = 1; i < memo.Length; i++)
            {
                long currentMaxValue = 0;
                foreach (var cakeType in cakes)
                {
                    if (i >= cakeType.Weight)
                    {
                        currentMaxValue = Math.Max(cakeType.Price + memo[i - cakeType.Weight], currentMaxValue);
                    }
                }
                memo[i] = currentMaxValue;
            }

            return memo[bagWeightCapacity];
        }

        public static void LongestPalindromSubsequenceTest()
        {
            System.Console.WriteLine(LongestPalindromSubsequenceDom("agbdba"));
        }

        public static int LongestPalindromSubsequence(string str)
        {
            var memo = new int[str.Length][];

            // define cols (number of cols = memo.Length : Zero based index)
            for (var row = 0; row < memo.Length; row++)
            {   
                memo[row] = new int[str.Length];
            }

            // initialize when Lenght is 1 char only
            for(int i=0; i < str.Length; i++)
            {
                memo[i][i] = 1;
            }

            for(int lenght = 2; lenght <= str.Length; lenght++)
            {
                for(int i = 0; i < str.Length - lenght + 1; i++)
                {
                    int j = i + lenght - 1;
                    if(lenght == 2 && str[i] == str[j])
                        memo[i][j] = 2;
                    else if(str[i] == str[j])
                        memo[i][j] = memo[i + 1][j-1] + 2;
                    else
                        memo[i][j] = Math.Max(memo[i + 1][j], memo[i][j - 1]);
                }
            }

            return memo[0][str.Length-1];
        }


        // this approach use only an array to memonized the values (instead of a matrix)
        public static int LongestPalindromSubsequenceDom(string str)
        {
            var memo = new int[str.Length];

            // initialize when Lenght is 1 char only
            for(int i=0; i < str.Length; i++)
            {
                memo[i] = 1;
            }

            for(int lenght = 2; lenght <= str.Length; lenght++)
            {
                for(int i = 0; i < str.Length - lenght + 1; i++)
                {
                    int j = i + lenght - 1;
                    if(str[i] == str[j])
                        memo[j] = memo[i + 1] + 2;
                    else
                        memo[i] = Math.Max(memo[i + 1], memo[i]);
                }
            }

            return memo[str.Length - 1];
        }

        public static void GetMaxProductOfPalindromeSubsequencesTest()
        {
            System.Console.WriteLine(GetMaxProductOfPalindromeSubsequences("eeegeeksforskeeggeeks"));
        }

        public static int GetMaxProductOfPalindromeSubsequences(string input)
        {
            var result = 0;
            for (var i = 1; i < input.Length - 1; i++)
            {
                var left = input.Substring(0, i);
                var right = input.Substring(i);
                result = Math.Max(result, LongestPalindromSubsequence(left) * LongestPalindromSubsequence(right));
            }
            return result;
        }

        // Some reference: https://www.youtube.com/watch?v=fV-TF4OvZpk
        public static int[] FindSubsetWithBigestSum()
        {
            return new int[] {0};
        }


        public static void LongestIncreasingSubsequenceLengthTest()
        {
            System.Console.WriteLine(LongestIncreasingSubsequenceLength(new int[] {9,5,21,28,2,7,19,22,1,6}));
        }

        public static int LongestIncreasingSubsequenceLength(int[] arr)
        {
            var result = 0;
            var memo = new int[arr.Length];
            // init memo values
            for (var i = 0; i < arr.Length; i++)
            {
                memo[i] = 1;
            }

            for (var i = 1; i < arr.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j]) continue;
                    memo[i] = Math.Max(memo[j], memo[j] + 1);
                    result = Math.Max(result, memo[i]);
                }
            }
            return result;
        }

        public static void GenSizeBoxesMemoTest()
        {
            //var memo = GenSizeBoxesMemo(9, 5, 2); // 4, 5
            //var memo = GenSizeBoxesMemo(9, 5, 3); // 2, 3, 4
            //var memo = GenSizeBoxesMemo(22, 7, 6); // -1
            //var memo = GenSizeBoxesMemo(26, 7, 6);
            //var memo = GenSizeBoxesMemo(10, 3, 3); // -1
        }

        public static long[] GenSizeBoxesMemo(long n, long k, int b)
        {
            var memo = new bool[k + 1][];
            
            // Initiallize Col[0] with 1 for all the rows
            for (var row = 0; row <= k; row++)
            {   
                var cols = new bool[n + 1];
                cols[0] = true;
                memo[row] = cols;
            }

            for (var row = 1; row <= k; row++)
            {
                for (var col = 1; col <= n; col++)
                {
                    if (col < row)
                        memo[row][col] = memo[row - 1][col];
                    else
                        memo[row][col] = memo[row - 1][col - row];

                    if (col == n && memo[row][col])
                    {
                        var candidates = GetCandidates(memo, row, n);
                        if (candidates != null && candidates.Length == b) return candidates;
                    }
                }
            }     
            return new long[]{ -1 };
        }

        private static long[] GetCandidates(bool[][] memo, int row, long n)
        {
            var candidates = new List<long>();
            while (n >= 0)
            {
                if (n >= row && memo[row][n - row])
                {
                    candidates.Add(row);
                    if (n - row == 0) return candidates.ToArray();
                    n -= row;
                }
                row--;
            }
            return null;
        }
    }

    public class CakeType
    {
        public int Weight { get; }
        public int Price { get; }

        public CakeType(int weight, int price)
        {
            Weight = weight;
            Price = price;
        }
    }
}