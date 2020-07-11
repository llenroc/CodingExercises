namespace InterviewCake
{
    public static class ChapterFour_SortingSearching
    {
        // Find Rotation Point
        public static int FindRotationPoint(int[] input)
        {
            if (input == null)
                throw new System.ArgumentNullException();

            if (input.Length == 0)
                return 0;

            if (input[0] <= input[input.Length - 1])
                return -1;

            return FindRotationIndex(input, 0, input.Length - 1);
        }

        private static int FindRotationIndex(int[] input, int ini, int end)
        {
            if (ini == end)
                return ini;

            int tmp = ini + ((end - ini) / 2);
            return (input[ini] > input[tmp]) ? FindRotationIndex(input, ini, tmp) : FindRotationIndex(input, tmp + 1, end);
        }
    }
}