using System;
using System.Collections.Generic;

namespace Screens
{
    public static class Amazon
    {
        public static int FindDistanceDiff(int[] values, int a, int b)
        {
            if (values == null || values.Length == 0) return -1;

            if (a == b) return 0;

            var tree = new Tree(new Node(values[0]));
            for (var i = 1; i < values.Length; i++) tree.Insert(values[i]);

            var dic = new Dictionary<int, int>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(tree.Root);
            
            int level = 1;
            dic.Add(tree.Root.value, level);

            while (q.Count > 0)
            {
                var n = q.Dequeue();
                
                if (n.left != null)
                {
                    q.Enqueue(n.left);

                    int newLevel = dic[n.value] + 1;
                    dic.Add(n.left.value, newLevel);
                }
                if (n.right != null)
                {
                    q.Enqueue(n.right);

                    int newLevel = dic[n.value] + 1;
                    dic.Add(n.right.value, newLevel);
                }

                if (dic.ContainsKey(a) && dic.ContainsKey(b)) return Math.Abs(dic[a] - dic[b]);
            }

            return -1;
        }

        // Complexity NxM (N=Features, M=Words)
        public static List<string> topFeatureRequests(
            int topFeatures, 
            List<string> possibleFeatures, 
            List<string> featureRequests)
        {
            if (possibleFeatures == null || featureRequests == null) throw new System.ArgumentNullException();

            Dictionary<string, int> featuresCounter = new Dictionary<string, int>();
            foreach (var pf in possibleFeatures) featuresCounter.Add(pf, 0);
            
            foreach (var fr in featureRequests) UpdateFeatureCounter(featuresCounter, fr);
            
            List<string> result = GetSortedTopFeatures(featuresCounter, topFeatures, possibleFeatures.Count);
            
            return result;

        }

        private static List<string> GetSortedTopFeatures(Dictionary<string, int> featuresCounter, int topFeatures, int possibleFeatures)
        {
            // Use the Freq table to build a new one based on the Ocurrence Number instead of the Feature name
            var set = new HashSet<int>();
            Dictionary<int, List<string>> featuresPerFreq = new Dictionary<int, List<string>>();
            foreach (KeyValuePair<string, int> fc in featuresCounter)
            {
                if (fc.Value == 0) continue;
                if (!featuresPerFreq.ContainsKey(fc.Value))
                {
                    featuresPerFreq.Add(fc.Value, new List<string>() { fc.Key });
                    set.Add(fc.Value);
                }
                else
                {
                    featuresPerFreq[fc.Value].Add(fc.Key);
                }
            }

            // Get only the list of Freq numbers in descending order
            int[] order = new List<int>(set).ToArray();
            Array.Sort(order);
            Array.Reverse(order);

            // based on the Order List, add the Features until reach the Top N 
            int resultLenght = Math.Min(topFeatures, possibleFeatures);
            List<string> result = new List<string>();
            foreach (int top in order)
            {
                if (featuresPerFreq.ContainsKey(top))
                {
                    foreach (var feature in featuresPerFreq[top])
                    {
                        if (result.Count >= resultLenght) return result;
                        result.Add(feature);
                    }
                }
            }
            return result;
        }

        private static void UpdateFeatureCounter(Dictionary<string, int> featuresCounter, string fr)
        {
            if (fr == null || fr.Length == 0) return;

            string[] words = fr.Split(' ');
            foreach (string w in words)
            {
                if (featuresCounter.ContainsKey(w)) featuresCounter[w]++;
            }
        }

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

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int v)
        {
            value = v;
        }
    }

    class Tree
    {
        public Node Root;

        public Tree(Node n)
        {
            Root = n;
        }

        public Node Insert(int v)
        {
            return Insert(Root, v);
        }

        private Node Insert(Node n, int v)
        {
            if (n == null) return new Node(v);

            if (v < n.value)
                n.left = Insert(n.left, v);
            else
                n.right = Insert(n.right, v);

            return n;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            traverse(root.right);
        }
    }

}