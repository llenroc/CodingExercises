using System;

namespace InterviewCake
{
    public static class Sorting
    {
        public static void FindRotationIndexTest()
        {
            var input = new [] {
                "lm",
                "ab",
                "cd",
                "ef",
                "gh",
                "hi",
                "jk"
            };

            Console.WriteLine(FindRotationIndex(input));
        }
        
        public static int FindRotationIndex(string[] input)
        {
            if (input == null) throw new System.ArgumentException();

            if (input[input.Length - 1].CompareTo(input[0]) == 1)
            {
                return 0; // there's no rotation
            }

            if (input.Length == 2)
            {
                return input[0].CompareTo(input[1]) == 1 ? 1 : 0;
            }

            return FindRotationIndex(input, 0, input.Length - 1);
        }

        private static int FindRotationIndex(string[] input, int ini, int end)
        {
            if (end - ini == 1)
            {
                return end;
            }

            var mid = ini + ((end - ini) / 2);
            return (input[mid].CompareTo(input[ini]) == -1) ?
                FindRotationIndex(input, ini, mid) : FindRotationIndex(input, mid, end);
        }
    }
}