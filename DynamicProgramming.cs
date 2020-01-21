using System;

namespace InterviewCake
{
    public static class DynamicProgramming
    {
        public static void GetNumberOfComboCoinsTest()
        {
            Console.WriteLine(GetNumberOfComboCoins(30, new [] {10, 15, 5}));
        }

        public static void GetMinNumberOfCoinsTest()
        {
            Console.WriteLine(GetMinNumberOfCoins(30, new [] {25, 15, 1}));
        }

        public static void MaxDuffelBagValueTest()
        {
            var cakes = new CakeType[] {
                new CakeType(2, 15),
                new CakeType(7, 160),
                new CakeType(3, 90)
            };

            System.Console.WriteLine(MaxDuffelBagValue(cakes, 20));
        }

        public static int GetNumberOfComboCoins(int amount, int[] coins)
        {
            if (coins == null || amount < 0) throw new System.ArgumentException("Coins can not be null and amount shoul be positive"); 
            
            var countTable = new int[amount + 1];
            countTable[0] = 1;

            foreach (var c in coins)
            {
                for (var i = 1; i < countTable.Length; i++)
                {
                    if (i >= c)
                    {
                        countTable[i] += countTable[i - c]; 
                    }
                }
            }

            return countTable[amount];
        }


        public static int GetMinNumberOfCoins(int amount, int[] coins)
        {
            if (coins == null || amount < 0) throw new System.ArgumentException("Coins can not be null and amount shoul be positive"); 
            
            var memo = new int[amount + 1];
            memo[0] = 0;

            for (var i = 1; i < memo.Length; i++)
            {
                memo[i] = int.MaxValue; 
            }

            for (var i = 1; i < memo.Length; i++)
            {
                foreach (var c in coins)
                {
                    if (c <= i && memo[i - c] != int.MaxValue &&  memo[i - c] + 1 < memo[i])
                    {
                        memo[i] = memo[i - c] + 1;
                    }
                }
            }

            return memo[amount];
        }

        public static long MaxDuffelBagValue(CakeType[] cakes, int bagCapacity)
        {
            var memo = new long[bagCapacity + 1];

            for (var i = 1; i < memo.Length; i++)
            {
                long currentMaxValue = 0;
                foreach (var cake in cakes)
                {
                    if (i >= cake.Size)
                    {
                        currentMaxValue = Math.Max(cake.Price + memo[i - cake.Size], currentMaxValue);
                    }
                }
                memo[i] = currentMaxValue;
            }

            return memo[bagCapacity];
        }
    }

    public class CakeType
    {
        public int Size { get; }
        public int Price { get; }

        public CakeType(int size, int price)
        {
            Size = size;
            Price = price;
        }
    }
}