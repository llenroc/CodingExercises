using System;
using System.Collections.Generic;

namespace InterviewCake
{
    public static class Recursion
    {
        public static void GetPermutationsTest()
        {
            var result = GetPermutations("012");

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static HashSet<string> GetPermutations(String inputString)
        {
            // Generate all permutations of the input string
            HashSet<string> result = new HashSet<string>();
        
            if (String.IsNullOrEmpty(inputString))
            {
                result.Add(inputString);
            }
            else
            {
                result = Permute(inputString, 0, inputString.Length - 1, result);
            }
        
            return result;
        }

        private static HashSet<string> Permute(string s, int ini, int end, HashSet<string> result)
        {
            if (ini == end)
            {
                result.Add(s);
            }
        
            for (int i = ini; i <= end; i++)
            {
                s = Swap(s, ini, i);
                result = Permute(s, ini + 1, end, result);
                s = Swap(s, ini, i);
            }
            return result;
        }

        private static string Swap(string s, int i, int j)
        {
            char[] charArray = s.ToCharArray();
            char tmp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = tmp;
            return new string(charArray);
        }

        public static void PermuteTest()
        {
            var result = Permute("dom");
            System.Console.WriteLine("Total Permutations: " + result.Count);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        // Easiest implementation and very friendly to read/understand (Cons: Bad performance)
        public static HashSet<string> Permute(string s)
        {
            if (s.Length <= 1) return new HashSet<string>(){s};

            var result = new HashSet<string>();
            var fisrt = s[0];
            var remainder = s.Substring(1);
            var words = Permute(remainder);
            foreach(var w in words)
            {
                for (var i = 0; i <= w.Length; i++) // use "<=" because we are adding 1 char to the word len ("first") 
                {
                    result.Add(w.Substring(0, i) + fisrt + w.Substring(i));
                }
            }
            return result;
        }
        
        public static void FindNumberOfCoinComboTest()
        {
            //Console.WriteLine("Total Combinations: " + FindNumberOfCoinCombo(30, new [] {10, 15, 5}));
            Console.WriteLine("Total Combinations: " + GetCombos(4, new [] {1, 2, 3}, 0, new LinkedList<int>()));
        }

        public static int FindNumberOfCoinCombo(int amount, int[] coins)
        {
            var result = 0;

            System.Console.WriteLine("Amount: $" + amount);
            System.Console.Write("Coins: ");
            foreach (var item in coins)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
            result = GetCombos(amount, coins, 0, new LinkedList<int>());

            return result;
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
    }
}