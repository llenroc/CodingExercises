using System;
using System.Collections.Generic;

namespace InterviewCake
{
    public class ArrayExercise
    {
        public static void MultiDimentional(int[,] multi)
        {
            int rowsCount = multi.GetUpperBound(0) - multi.GetLowerBound(0) + 1;
            int colsCount = multi.GetUpperBound(1) - multi.GetLowerBound(1) + 1;
            Console.WriteLine("Total Rows: " + rowsCount);
            Console.WriteLine("Total Cols: " + colsCount);
            
            for (int i = 0; i < rowsCount; i++)
            {
                Console.WriteLine("Row({0}): ", i);
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write("Col({0}): ", j);
                    Console.Write("{0}{1}", multi[i,j], j == colsCount - 1 ? "" : " ");
                }
                Console.WriteLine();
            }
        }

        public static void Jagged(int[][] jagged)
        {
            int rowsCount = jagged.Length;
            int colsCount = jagged[0].Length;
            Console.WriteLine("Total Rows: " + rowsCount);
            Console.WriteLine("Total Cols: " + colsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                Console.WriteLine("Row({0}): ", i);
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write("Col({0}): ", j);
                    Console.Write("{0}{1}", jagged[i][j], j == (jagged[i].Length - 1) ? "" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}