using System;
using System.Collections.Generic;

namespace Screens
{
    public static class Amazon
    {
        public static void GetNumberAmazonTreasureTrucksTest()
        {
            var grid = new int[,]
            {
                {1, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 0}
            };

            System.Console.WriteLine(numberAmazonTreasureTrucks(4, 4, grid));
        }

        public static  int numberAmazonTreasureTrucks(int rows, int column, int[,] grid)
        {
            // Validate input (Edge cases)
            if (grid == null) return 0;
            if (rows == 0 && column == 0) return 0;
            
            // creating a DT to memoize previous results
            var memo = new int[rows][];
            for (var i = 0; i < memo.Length; i++) memo[i] = new int[column];
            memo[0][0] = grid[0,0];
            
            // iterate through each cell of the grid
            var result = memo[0][0];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if (i == 0 && j == 0) continue;
                    
                    if (grid[i, j] == 1)
                    {
                        if (i == 0 || j == 0)
                        {
                            if ((i == 0 && grid[i, j - 1] == 0) || // check left only
                                (j == 0 && grid[i - 1, j] == 0)) // check Top
                            {
                                result++;
                            }
                        }
                        else
                        {
                            if (grid[i, j - 1] != 0 && grid[i - 1, j] != 0)
                            {
                                result = Math.Min(memo[i][j - 1], memo[i - 1][j]);
                            }
                            else
                            {
                                if (memo[i][j - 1] != 0)
                                    result = memo[i][j - 1];
                                else if (memo[i - 1][j] != 0)
                                    result = memo[i - 1][j];
                                else
                                    result++;
                            }
                        }
                        memo[i][j] = result;
                    }
                }
                    
            }
            
            return result;
        }

        public static void GetRequiredLinksTest()
        {
            var input = new int[][]
            {
                new [] { 1, 2 },
                new [] { 1, 3 },
                new [] { 2, 4 },
                new [] { 3, 4 },
                new [] { 3, 6 },
                new [] { 6, 7 },
                new [] { 4, 5 }
            };

            var result = GetRequiredLinks(7, 7, input); 
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
        
        public static int[] GetRequiredLinks(int routers, int links, int[][] input)
        {
            if (input == null || input.Length == 0) throw new System.ArgumentException("Input should have elements");

            var result = new List<int>();
            var dic = new Dictionary<int, HashSet<int>>();
            foreach (var row in input)
            {
                if (!dic.ContainsKey(row[0])) dic.Add(row[0], new HashSet<int>());
                dic[row[0]].Add(row[1]);
            }

            for (var i = 2; i < routers; i++)
            {
                var visited = new HashSet<int>();
                var skipLinks = dic.ContainsKey(i) ? new HashSet<int>(dic[i]) : new HashSet<int>();  
                foreach (var entry in dic)
                {
                    if (entry.Key != i)
                    {
                        if (!skipLinks.Contains(entry.Key) || visited.Contains(entry.Key)) visited.Add(entry.Key);
                        
                        foreach (var l in entry.Value) if (l != i) visited.Add(l);
                    }
                }
                if (visited.Count < links - 1) result.Add(i);
            }
            return result.ToArray();
        }

        public static string RunLengthEncoding(string s)
        {
            string result = string.Empty;

            char prev = s[0];
            int counter = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == prev)
                {
                    counter++;
                }
                else
                {
                    result += counter.ToString() + prev.ToString();
                    counter = 1;
                }
                prev = s[i];
            }

            result += counter.ToString() + prev.ToString();

            return result;
        }

    }
}