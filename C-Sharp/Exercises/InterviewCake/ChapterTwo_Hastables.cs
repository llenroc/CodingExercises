namespace InterviewCake
{
    public static class ChapterTwo_Hashtables
    {
        // Top Scores (better than nLog(n))
        public static int[] SortScores(int[] input, int highestPossibleScore)
        {
            if (input == null)
                throw new System.ArgumentNullException();

            bool[] tmp = new bool[highestPossibleScore + 1];
            int[] result = new int[input.Length];

            foreach (int score in input)
            {
                tmp[score] = true;
            }

            int index = 0;
            for (int i = tmp.Length - 1; i >= 0; i--)
            {
                if (tmp[i])
                    result[index++] = i;
            }

            return result;
        }
    }
}