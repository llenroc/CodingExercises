using System;
using System.Collections.Generic;

namespace InterviewCake
{
    class Program
    {
        static void Main(string[] args)
        {
            /* MISCELANEOUS */
            // TestMultiDimentional();
            // TestJagged();

            /* Zillow Screen */
            // Zillow.GetOptimalGasPurchaseTest();
            // Zillow.MicrosoftTest();

            /* Interview.io practice Interview */
            // InterviewIo.TestTriplets();
            
            /* Lowe's Screen */
            // TODO:
            // Lowes.ToJsonTest();

            /* Strivr Screen */
            //Strivr.GetPlayerScoreTest();

            /* Foursquare Screen */
            // Foursquare.MaxFunTest();

            /* Facebook */
            Facebook.GetMinContainingLengthTest();

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
            //Recursion.GetPermutationsTest();
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

//            List<int> result = IndeedFindRectangle.GetRectangle(image3);
//            foreach (var number in result)
//            {
//                Console.WriteLine(" -> " + number);
//            }

            //Console.WriteLine(IndeedFindRectangle.IncludeBlank("hello world"));

            //Console.WriteLine(IndeedFindRectangle.IsBracketsBalanced("{]}"));
            
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