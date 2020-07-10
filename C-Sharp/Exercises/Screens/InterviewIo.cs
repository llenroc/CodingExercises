using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.

public static class InterviewIo
{
    public static void TestTriplets()
    {

        
        /*
        -4 -1 -1 0 1 2
        */
        var result = getTriplets(new int[] {-4, -1, -1, 0, 1, 2});
        foreach (var t in result)
        {
            Console.WriteLine(t[0] + "," + t[1] + "," + t[2]);
        }
    }
    
    public static List<int[]> getTriplets(int[] numbers)
    {
        var result = new List<int[]>();
        var sorted = new List<int>(numbers);
        var previous = 0;
        var inital = true;

        for (var i = 0; i < sorted.Count; i++) // -1
        {
            if (inital)
            {
                previous = sorted[i];
                inital = false;
            }
            else
            {
                if (sorted[i] == previous)
                {
                    continue;
                }
            }

            var element = sorted[i];
            var remainder = element * -1; // 1
            
            var end = sorted.Count -1;
            for (var j = i + 1; j < sorted.Count && j < end; j++) // j = 0, end = 2
            {
                var tmp = sorted[j] + sorted[end]; // tmp = 1
                if (tmp == remainder)
                {
                    var triplet = new int[] { sorted[i], sorted[j], sorted[end] };
                    result.Add(triplet);

                    // reset "end" pointer
                    end = sorted.Count -1;
                }
                else
                {
                    if (tmp > remainder)
                    {
                        end--;
                        j--; // To keep "j" in the same position
                    }
                }
            }
            previous = sorted[i];
        }
        
        return result;
    }
}


/* 
Your previous Plain Text content is preserved below:

Welcome to your interviewing.io interview.

Once you and your partner have joined, a voice call will start automatically.

Use the language dropdown near the top right to select the language you would like to use.

You can run code by hitting the 'Run' button near the top left.

Enjoy your interview!


Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0?
Find all unique triplets in the array which gives the sum of zero.

Note: The solution set must not contain duplicate triplets.

For example, given array S = [-1, 0, 1, 2, -1, -4],
A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]

---


-4 -1 -1 0 1 2    
    ^
       ^
             ^


4
    
 -1 -1 0 1 2   


 */