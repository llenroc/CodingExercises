using System;
using System.Collections.Generic;

namespace Exercises
{
    public static class Recursion
    {
        public static void FindNumberOfCoinComboTest()
        {
            //Console.WriteLine("Total Combinations: " + FindNumberOfCoinCombo(30, new [] {10, 15, 5}));
            Console.WriteLine("Total Combinations: " + GetCombos(4, new [] {1, 2, 3}, 0, new LinkedList<int>()));
        }

        private static int GetCombos(int amount, int[] coins, int currCoin, LinkedList<int> comboCoins)
        {
            if (amount < 0) 
            {
                //comboCoins.RemoveLast();
                return 0;
            }
             
            if (amount == 0)
            {
                // foreach (var item in comboCoins) System.Console.Write(item + " ");
                
                return 1;
            }
            System.Console.WriteLine(coins[currCoin]);

            var combos = 0;
            for (int coin = currCoin; coin < coins.Length; coin++)
            {
                //System.Console.WriteLine();
                //comboCoins.AddFirst(coins[coin]);
                var newAmount = amount - coins[coin];
                var tmp = GetCombos(newAmount, coins, coin, comboCoins);
                combos += tmp;
                //comboCoins.RemoveLast();
            }

            return combos;
        }

        
        private static void PrintCombos(int amount, int[] coins, int currCoin, LinkedList<int> comboCoins)
        {
            if (amount < 0) {
                comboCoins.RemoveLast();
                return;
            }; 
            if (amount == 0)
            {
                foreach (var item in comboCoins)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }

            for (int coin = currCoin; coin < coins.Length; coin++)
            {
                comboCoins.AddFirst(coins[coin]);
                GetCombos(amount - coins[coin], coins, coin, comboCoins);
                comboCoins.RemoveLast();
            }
        }


        // public static void GetBoxSizesTest()
        // {
        //     //var result = GetBoxSizes(5, 3, 9);
        //     //var result = GetBoxSizes(7, 6, 22);
        //     var result = GetBoxSizes(7, 6, 26);
        // }

        // public static long[] GetBoxSizes(long k, long b, long n)
        // {
        //     var sizes = new Queue<long>();
        //     for (var i = 1; i <= n - b; i++)
        //     {
        //         for (var j = i; j <= k; j++) sizes.Enqueue(j);

        //         var result = GetNumbers(sizes, b, k, n);
        //         if (result != null) return result.ToArray();
        //     }
        //     return new long[] { -1 };
        // }

        // private static List<long> GetNumbers(Queue<long> sizes, long trips, long maxSize, long total)
        // {
        //     var result = new List<long>();

        //     while (sizes.Count > 0)
        //     {
        //         var last = result.Count - 1;
        //         if (result.Count == trips - 1)
        //         {
        //             if (total > result[last] && total <= maxSize)
        //             {
        //                 result.Add(total);
        //                 return result;
        //             }
                    
        //             total += result[last];
        //             result.RemoveAt(last);
        //         }

        //         var n = sizes.Dequeue();
        //         result.Add(n);
        //         total -= n;
        //     }

        //     return null;
        // }
    }
}