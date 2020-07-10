using System;
using System.Collections.Generic;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /* MISCELANEOUS */
            // TestMultiDimentional();
            // TestJagged();

            /**************************************************************

            INTERVIEWS: REAL QUESTIONS (Screens and OnSite)

            ***************************************************************/

            /* Microsoft Screen */
            //MS.GetDicLowestStringTest();
            //Microsoft.GetWordsTest();
            //Microsoft.GetMaximalNetworkRankTest();
            //Microsoft.GetLongestConcatTest();
            //Microsoft.OnLineTest();


            /* Zillow Screen */
            // Zillow.GetOptimalGasPurchaseTest();
            // Zillow.IsBSTTest();

            /* Interview.io (practice Interview) */
            // InterviewIo.TestTriplets();
            
            /* Lowe's Screen */
            // TODO:
            // Lowes.ToJsonTest();

            /* Strivr Screen */
            //Strivr.GetPlayerScoreTest();

            /* Foursquare Screen */
            // Foursquare.MaxFunTest();

            /* Facebook On Site*/
            //Facebook.GetMinContainingLengthTest();
            //Facebook.WordDiccTest();
            
            /* Byte by Byte - DP Exercises: https://www.byte-by-byte.com/6-dynamic-programming-questions */
            //BytebyByte.GetSmalestChangeTest();
            //BytebyByte.GetLongestCommonSubstringTest();
            //BytebyByte.FibonacciTest();
            //BytebyByte.GetBigestSquareSubmatrixTest();
            //BytebyByte.GetMaxtrixProductTest();
            //BytebyByte.GetKnapsackTest();

            /* Amazon - OnLine Assesment */
            Amazon.GetNumberAmazonTreasureTrucksTest();
            // Amazon.GetRequiredLinksTest();
            
            /**************************************************************

            INTERVIEW CAKE COURSE EXERCISES

            ***************************************************************/
            
            /* 3 - GREEDY ALGORITHMS */
            // Greedy.GetHighestTripletPruductTest();
            // Greedy.GetMaxStockProfit();


            /* 4 - SORTING */
            //Sorting.FindRotationIndexTest();


            /* 5 - BINARY TREE & GRAPH */
            //BinaryTree.IsBalanceTest();
            //BinaryTree.IsBSTTest();
            //BinaryTree.GetSecondLargestTest();
            // TODO: Include test methods for Graph.cs
            //Graph.GetShortestPathCostTest();


            /* 6 - DYNAMIC PROGRAMMING AND RECURSION */
            //Recursion.PermuteTest();
            //Recursion.FindNumberOfCoinComboTest();
            //Recursion.SubSequencesTest();

            //DynamicProgramming.GetMinNumberOfCoinsTest();
            //DynamicProgramming.GetAllNumberOfComboCoinsTest();
            //DynamicProgramming.MaxDuffelBagValueTest();
            //DynamicProgramming.GenMinNumberOfCoinsComboTest();
            //DynamicProgramming.LongestPalindromSubsequenceTest();
            //DynamicProgramming.GetMaxProductOfPalindromeSubsequencesTest();
            //DynamicProgramming.LongestIncreasingSubsequenceLengthTest();
            //DynamicProgramming.GenSizeBoxesMemoTest(); // TODO

            /* 7 - Queues and Stacks */
            //QueueStack.PhoneNumberLetterCombinationsTest();
            //QueueStack.FindMazeExitTest();
        }

        private static void TestMultiDimentional()
        {
            var image1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 0, 0, 0, 1}
            };
        
            var image2 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 0}
            };

            var image3 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 0, 0},
                {1, 1, 1, 1, 1, 0, 0}
            };

            var image4 = new int[,]
            {
                {0, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1}
            };

            var image5 = new int[,]
            {
                {0}
            };

//            List<int> result = Indeed.GetRectangle(image3);
//            foreach (var number in result)
//            {
//                Console.WriteLine(" -> " + number);
//            }

            //Console.WriteLine(Indeed.IncludeBlank("hello world"));

            //Console.WriteLine(Indeed.IsBracketsBalanced("{]}"));
            
            ArrayExercise.MultiDimentional(image1);
        }

        private static void TestJagged()
        {
            // Declare the array of two elements.
            int[][] jagged = new int[3][];

            // Initialize the elements.
            jagged[0] = new int[5] { 1,2,3,4,5 };
            jagged[1] = new int[5] { 6,7,8,9,0 };
            jagged[2] = new int[5] { 2,4,5,8,0 };
            
            ArrayExercise.Jagged(jagged);
        }


    }
}