using System;
using System.Collections.Generic;

namespace InterviewCake
{
/*
Imagine we have an image. We'll represent this image as a simple 2D array where every pixel is a 1 or a 0. The image you get is known to have a single rectangle of 0s on a background of 1s.

Write a function that takes in the image and returns one of the following representations of the rectangle of 0's: top-left coordinate and bottom-right coordinate OR top-left coordinate, width, and height.

image1 = [
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 0, 0, 0, 1],
  [1, 1, 1, 0, 0, 0, 1],
  [1, 1, 1, 1, 1, 1, 1],
]

Sample output variations (only one is necessary):

findRectangle(image1) =>
  x: 3, y: 2, width: 3, height: 2
  2,3 3,5 -- row,column of the top-left and bottom-right corners

Other test cases:

image2 = [
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 0],
]

findRectangle(image2) =>
  x: 6, y: 4, width: 1, height: 1
  4,6 4,6

image3 = [
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 0, 0],
  [1, 1, 1, 1, 1, 0, 0],
]

findRectangle(image3) =>
  x: 5, y: 3, width: 2, height: 2
  3,5 4,6
  
image4 = [
  [0, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
]

findRectangle(image4) =>
  x: 0, y: 0, width: 1, height: 1
  0,0 0,0

image5 = [
  [0],
]

findRectangle(image5) =>
  x: 0, y: 0, width: 1, height: 1
  OR
  0,0 0,0
  (topleft) (bottomright)
  (row, column)
n: number of rows in the input image
m: number of columns in the input image


*/
  class Indeed {
      public static List<int> GetRectangle(int[,] image)
      {
          List<int> result = new List<int>();
          int rowsCount = image.GetUpperBound(0) - image.GetLowerBound(0) + 1;
          int colsCount = image.GetUpperBound(1) - image.GetLowerBound(1) + 1;
          bool found = false;
          
          for (int i = 0; i < rowsCount; i++)
          {
            for (int j = 0; j < colsCount; j++)
            {
              if (!found && image[i, j] == 0)
              {
                result.Add(j);
                result.Add(i);
                found = true;
              }
              if (found)
              {
                var l = image[i, j];
                // If right and bottom side are "1" or boundary then this is the Right Corner 
                if (l == 0 &&
                    (j == colsCount - 1 || image[i, j + 1] == 1) &&
                    (i == rowsCount - 1 || image[i + 1, j] == 1))
                {
                  result.Add(j);
                  result.Add(i);
                  return result;
                }
              }
            }
          }
          return result;
      }
      
      public static string IncludeBlank(string input)
      {
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
          if (i == input.Length - 1 || input[i] == ' ' || input[i + 1] == ' ')
          {
            result += input[i];
          }
          else
          {
            result += input[i] + " ";
          }
        }

        return result;
      }

      public static bool IsBracketsBalanced(string input)
      {
        Stack<char> s = new Stack<char>();
        HashSet<char> brackets = new HashSet<char>(new char[]{'[','{',']','}'});

        foreach (var c in input)
        {
          if (brackets.Contains(c))
          {
            if (c == ']' || c == '}')
            {
              if (s.Count == 0)
              {
                return false;
              }
              var tmp = s.Pop();
              if ((c == ']' && tmp != '[') || (c == '}' && tmp != '{'))
              {
                return false;
              }
            }
            else
            {
              s.Push(c);
            }
          }
        }

        return true;
      }

      // hello world -> h e l l o w o r l d
      // valid brackets
      

/*

You are a developer for a university. Your current project is to develop a system for students to find courses they share with friends. The university has a system for querying courses students are enrolled in, returned as a list of (ID, course) pairs.

Write a function that takes in a list of (student ID number, course name) pairs and returns, for every pair of students, a list of all courses they share.

Sample Input:

student_course_pairs_1 = [
  ["58", "Software Design"],
  ["58", "Linear Algebra"],
  ["94", "Art History"],
  ["94", "Operating Systems"],
  ["17", "Software Design"],
  ["58", "Mechanics"],
  ["58", "Economics"],
  ["17", "Linear Algebra"],
  ["17", "Political Science"],
  ["94", "Economics"],
  ["25", "Economics"],
]

Sample Output (pseudocode, in any order):

find_pairs(student_course_pairs_1) =>
{
  [58, 17]: ["Software Design", "Linear Algebra"]
  [58, 94]: ["Economics"]
  [58, 25]: ["Economics"]
  [94, 25]: ["Economics"]
  [17, 94]: []
  [17, 25]: []
}

Additional test cases:

Sample Input:

student_course_pairs_2 = [
  ["42", "Software Design"],
  ["0", "Advanced Mechanics"],
  ["9", "Art History"],
]

Sample output:

find_pairs(student_course_pairs_2) =>
{
  [0, 42]: []
  [0, 9]: []
  [9, 42]: []
}

*/

//    static void Main(String[] args) {
//        
//        string[][] studentCoursePairs1 = {
//          new string[] {"58", "Software Design"},
//          new string[] {"58", "Linear Algebra"},
//          new string[] {"94", "Art History"},
//          new string[] {"17", "Software Design"},
//          new string[] {"58", "Mechanics"},
//          new string[] {"58", "Economics"},
//          new string[] {"17", "Linear Algebra"},
//          new string[] {"17", "Political Science"},
//          new string[] {"94", "Economics"},
//          new string[] {"25", "Economics"},
//        };
//
//        string[][] studentCoursePairs2 = {
//          new string[] {"42", "Software Design"},
//          new string[] {"0", "Advanced Mechanics"},
//          new string[] {"9", "Art History"},
//        };
//        
//        var result = GetStudentCoursePairs(studentCoursePairs2);
//    }
    

    public static void TestGetStudentCoursePairs() {
        
        string[][] studentCoursePairs1 = {
          new string[] {"58", "Software Design"},
          new string[] {"58", "Linear Algebra"},
          new string[] {"94", "Art History"},
          new string[] {"17", "Software Design"},
          new string[] {"58", "Mechanics"},
          new string[] {"58", "Economics"},
          new string[] {"17", "Linear Algebra"},
          new string[] {"17", "Political Science"},
          new string[] {"94", "Economics"},
          new string[] {"25", "Economics"},
        };

        string[][] studentCoursePairs2 = {
          new string[] {"42", "Software Design"},
          new string[] {"0", "Advanced Mechanics"},
          new string[] {"9", "Art History"},
        };
        
        var result = GetStudentCoursePairs(studentCoursePairs1);
    }
    
    private static List<Tuple<Tuple<string, string>, string[]>> GetStudentCoursePairs(string[][] input)
    {
        
        // Create Freq Table (Dictionary)
        var freq = getFreqTable(input);
        PrintFreqTable(freq);

        // Create Pairs DS
        var pairs = getPairs(freq);
        PrintPairs(pairs);

        // Get common Subjects
        var result = getCommonSubjectsPerPair(input, freq, pairs);
        PrintCommonSubjectsPerPair(result);

        return result;
    }
    
    private static Dictionary<string, List<string>> getFreqTable(string[][] input)
    {
        var result = new Dictionary<string, List<string>>();
        var rowCount = input.Length;
        var colCount = input[0].Length;
        
        for (var i = 0; i < rowCount; i++)
        {
            if (!result.ContainsKey(input[i][0]))
            {
                result.Add(input[i][0], new List<string>());
            }
            
            for (var j = 1; j < colCount; j++)
            {
                result[input[i][0]].Add(input[i][j]);
            }
        }
        return result;
    }
    
    private static List<Tuple<string, string>> getPairs(
        Dictionary<string, 
        List<string>> freq)
    {
        var result = new List<Tuple<string, string>>();
        var ids = new string[freq.Count];
        var index = 0;
        
        foreach(var entry in freq)
        {
            ids[index++] = entry.Key;
        }
        
        for (var i = 0; i < ids.Length; i++)
        {
            for (var j = i + 1; j < ids.Length; j++)
            {
                result.Add(new Tuple<string, string>(ids[i], ids[j]));
            }
        }
        
        return result;
    }
    
    private static List<Tuple<Tuple<string, string>, string[]>> getCommonSubjectsPerPair(
        string[][]input, 
        Dictionary<string, List<string>> freq, 
        List<Tuple<string, string>> pairs)
    {
        var result = new List<Tuple<Tuple<string, string>, string[]>>();
        var index = 0;
        foreach (var t in pairs)
        {
            var list = new List<string>();
            foreach (var x in freq[t.Item1]) // subjects Item1
            {
                foreach (var y in freq[t.Item2]) // subjects Item2
                {
                    if (x == y)
                    {
                        list.Add(y);
                    }
                }
            }
            result.Add(new Tuple<Tuple<string, string>, string[]>(t, list.ToArray()));
        }
        return result;
    }
    
    private static void PrintCommonSubjectsPerPair(List<Tuple<Tuple<string, string>, string[]>> result)
    {
      Console.WriteLine(">>>>>>>>>> Common Subjects <<<<<<<<<<<");

      foreach (var entry in result)
      {
        Console.WriteLine("Pair: " + entry.Item1.Item1 + "," + entry.Item1.Item2);
        foreach (var s in entry.Item2)
        {
          Console.Write(s + ",");
        }

        Console.WriteLine();
      }
    }

    private static void PrintPairs(List<Tuple<string, string>> pairs)
    {
      Console.WriteLine(">>>>>>>>>> Pairs <<<<<<<<<<<");
      foreach (var entry in pairs)
      {
        Console.WriteLine("Pair: " + entry.Item1 + ", " + entry.Item2);
      }
    }

    private static void PrintFreqTable(Dictionary<string, List<string>> freq)
    {
      Console.WriteLine(">>>>>>>>>> Freq Table <<<<<<<<<<<");
      foreach (var entry in freq)
      {
        Console.Write(entry.Key + ": ");
        foreach (var subject in entry.Value)
        {
          Console.Write(subject + ",");
        }

        Console.WriteLine();
      }
    }

  }
}

