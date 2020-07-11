namespace InterviewCake
{
    public static class ChapterSix_DynamicProgramming
    {
        // Making Change
        public static int GetCoinChangeWays(int[] coins, int amount)
        {
            int[] tmp = new int[amount + 1];
            tmp[0] = 1;
            foreach (int c in coins)
            {
                for (int i = 1; i < tmp.Length; i++)
                {
                    if (i >= c)
                    {
                        tmp[i] += tmp[i - c]; 
                    }
                }
            }
            return tmp[amount];
        }

        public static int GetEfficientCoinChange(int[] coins, int amount)
        {
            int[] memo = new int[amount + 1];
            for (var i = 1; i < memo.Length; i++)
            {
                memo[i] = int.MaxValue; 
            }

            foreach (int c in coins)
            {
                for (int i = 1; i < memo.Length; i++)
                {
                    if (i >= c && memo[i - c] != int.MaxValue && memo[i - c] + 1 < memo[i])
                    {
                        memo[i] = memo[i - c] + 1; 
                    }
                }
            }
            return memo[amount];
        }
    }
}