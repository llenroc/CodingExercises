using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class MaximunSubArray
    {
        public static int[] GetMaxSubarray(int[] arr)
        {
            int dimention = arr.Length;
            int[][] memo = new int[dimention][];
            for (int i = 0; i < memo.Length; i++) memo[i] = new int[dimention];

            int startIndex = 0;
            int endIndex = 0;
            int sumMaxSubArray = arr[0];
            for (int i = 0; i < memo.Length; i++)
            {
                for (int j = i; j < memo[i].Length; j++)
                {
                    if (j < i) continue;

                    memo[i][j] = (j == 0) ? arr[j] : arr[j] + memo[i][j - 1];
                    if (j == 0 || sumMaxSubArray <= memo[i][j])
                    {
                        startIndex = i;
                        endIndex = j;
                        sumMaxSubArray = memo[i][j];
                    }
                }
            }

            int sumMaxSubSequence = int.MinValue;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i == startIndex)
                    sumMaxSubSequence = arr[i];
                else
                    sumMaxSubSequence += Math.Max(0, arr[i]); 
            }

            return new int[] { sumMaxSubArray, sumMaxSubSequence };
        }
    }
}