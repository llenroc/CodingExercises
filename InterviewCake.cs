using System;
using System.Collections.Generic;

namespace InterviewCake
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Test MultiDimentional");
            // TestMultiDimentional();
            
            // Console.WriteLine("-------------------------");
            
            // Console.WriteLine("Test Jagged");
            // TestJagged();

            // Triplets.TestTriplets();

            // HighestTripletPruduct.GetHighestTripletPruductTest();

            StockProfit.GetMaxProfitTest();
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