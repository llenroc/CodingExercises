using System;

namespace InterviewCake
{
    public static class ChapterThree_GreedyAlgorithms
    {
        // Highest product of 3 values
        public static int GetHighestProduct(int[] input)
        {
            if (input == null || input.Length < 3)
                throw new System.ArgumentException("At least e values are required");

            if (input.Length == 3)
                return input[0] * input[1] * input[2];

            int highestProductOf2 = input[0] * input[1];
            int lowestProductOf2 = input[0] * input[1];
            
            int highest = Math.Max(input[0], input[1]);
            int lowest = Math.Min(input[0], input[1]);

            int highestProductOf3 = Math.Max(highestProductOf2 * input[2], lowestProductOf2 * input[2]);
            
            for (int i = 2; i < input.Length; i++)
            {
                int current = input[i];

                highestProductOf3 = Math.Max(highestProductOf3, 
                    Math.Max(lowestProductOf2 * current, highestProductOf2 * current));
                
                lowestProductOf2 = Math.Min(lowestProductOf2, Math.Min(current * lowest, current * highest));
                highestProductOf2 = Math.Max(highestProductOf2, Math.Max(current * lowest, current * highest));

                highest = Math.Max(current, highest);
                lowest = Math.Min(current, lowest);
            }


            return highestProductOf3;
        }
    }
}