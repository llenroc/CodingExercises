using System;
using System.Collections.Generic;

namespace Exercises
{
    public static class QueueStack
    {
        // table[i] stores all characters that corresponds to ith digit in phone
        public static String[] table = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" }; 

        public static void PhoneNumberLetterCombinationsTest() 
        {
            var phoneNumber = new []{ 5, 3 };
            var result = PhoneNumberLetterCombinations(phoneNumber, phoneNumber);
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        } 
        
        // From https://www.geeksforgeeks.org/iterative-letter-combinations-of-a-phone-number/
        public static List<string> PhoneNumberLetterCombinations(int[] phoneNumber, int[] n)
        {
            var result = new List<string>();
            var q = new Queue<string>();
            
            q.Enqueue("");

            while (q.Count > 0)
            {
                var s = q.Dequeue();
                if (s.Length == n.Length)
                {
                    result.Add(s);
                }
                else
                {
                    var digit = phoneNumber[s.Length];
                    var chars = table[digit];
                    for (var i = 0; i < chars.Length; i++)
                    {
                        q.Enqueue(s + chars[i]);
                    }
                }
            }

            return result;
        }

        public static void FindMazeExitTest()
        {
            int[][] jagged = new int[5][];

            // Initialize the elements.
            jagged[0] = new [] { 0, 0, 0, 0, 1 };
            jagged[1] = new [] { 0, 0, 0, 0, 1 };
            jagged[2] = new [] { 1, 1, 0, 0, 1 };
            jagged[3] = new [] { 0, 0, 0, 1, 0 };
            jagged[4] = new [] { 2, 1, 0, 0, 1 };

            System.Console.WriteLine(FindMazeExit(jagged));
        }

        public static bool FindMazeExit(int[][] maze)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(new Tuple<int, int>(0, 0));
            maze[0][0] = -1;

            // BFS
            while (q.Count > 0)
            {
                Tuple<int, int> current = q.Dequeue();
                if (maze[current.Item1][current.Item2] == 2) return true;

                EnqueueNeighbores(current, maze, q);
            }
            
            return false;
        }

        private static void EnqueueNeighbores(Tuple<int, int> current, int[][] maze, Queue<Tuple<int, int>> q)
        {
            // zero based
            int rows = maze.Length - 1;
            int cols = maze[0].Length - 1;

            // Rigth
            if (current.Item2 < cols && maze[current.Item1][current.Item2 + 1] != 1 && maze[current.Item1][current.Item2 + 1] != -1) 
            {
                q.Enqueue(new Tuple<int, int>(current.Item1, current.Item2 + 1));
                if (maze[current.Item1][current.Item2 + 1] != 2) maze[current.Item1][current.Item2 + 1] = -1;
            }
            // Left
            if (current.Item2 > 0 && maze[current.Item1][current.Item2 - 1] != 1 && maze[current.Item1][current.Item2 - 1] != -1)
            {
                q.Enqueue(new Tuple<int, int>(current.Item1, current.Item2 - 1));
                if (maze[current.Item1][current.Item2 - 1] != 2) maze[current.Item1][current.Item2 - 1] = -1;
            }
            // Top
            if (current.Item1 > 0 && maze[current.Item1 - 1][current.Item2] != 1 && maze[current.Item1 - 1][current.Item2] != -1)
            {
                q.Enqueue(new Tuple<int, int>(current.Item1 - 1, current.Item2));
                if (maze[current.Item1 - 1][current.Item2] != 2) maze[current.Item1 - 1][current.Item2] = -1;
            }
            // Bottom
            if (current.Item1 < rows && maze[current.Item1 + 1][current.Item2] != 1 && maze[current.Item1 + 1][current.Item2] != -1) 
            {
                q.Enqueue(new Tuple<int, int>(current.Item1 + 1, current.Item2));
                if (maze[current.Item1 + 1][current.Item2] != 2) maze[current.Item1 + 1][current.Item2] = -1;
            }
        }
    }
}