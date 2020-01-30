using System.Collections.Generic;
using System;

public static class Foursquare
{

    /*
     * Complete the 'maxFun' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY employees as parameter.
     */
     
     // [ [manager_id, employee_id, fun_score], [0, 1, 5], [1, 2, 2] ....... ]
     //              5 
     //            /   \
     //           2     7
     //          / \   / \
     //         3   4 1   2
     //          
     // Expected : 15    

// [invited, not_invited]

//    5       5 => [15, 14]
//  2   7     2 => [2, 7]    7 => [7, 3] --- Level 2
// 3 4 1 2  

/*
0 1 5  -- X
1 2 2  -- 2          
1 3 7  -- X
2 4 3  -- 4
2 5 4  
3 6 1
3 7 2
*/
    public static void MaxFunTest()
    {
        List<List<int>> employeesHierarchy = new List<List<int>> ();
        employeesHierarchy.Add( new List<int> {0, 1, 5} );
        employeesHierarchy.Add( new List<int> {1, 2, 2} );
        employeesHierarchy.Add( new List<int> {1, 3, 7} );
        employeesHierarchy.Add( new List<int> {2, 4, 3} );
        employeesHierarchy.Add( new List<int> {2, 5, 4} );
        employeesHierarchy.Add( new List<int> {3, 6, 1} );
        employeesHierarchy.Add( new List<int> {3, 7, 2} );

        //System.Console.WriteLine(MaxFun(employeesHierarchy));
        System.Console.WriteLine(GetMaxScore(employeesHierarchy));
    }

    public static int MaxFun(List<List<int>> employees)
    {
        // map of manager id to list of employee id => traverse a employees directs (5, [2, 7])
        // map of employee id to score scoreMap => get score for any employee (1, 5)   
        var directsMap = GetDirectsMap(employees);
        var employeesScoreMap = GetEmployeesScoreMap(employees);
        
        var result = MaxFunRecursive(employees, employees[0], directsMap, employeesScoreMap, new [] {0, 5}, false);

        return Math.Max(result[0], result[1]);
    }
    
    
    /* 
     //              5 
     //            /   \
     //           2     7
     //          / \   / \
     //         3   4 1   2
    */


    // From https://leetcode.com/discuss/interview-question/447750/Google-onsite-interview-round
    private static int GetMaxScore(List<List<int>> employees) 
    {
        var employeeDataMap = new Dictionary<int, Dictionary<int, int>>();
        var scoreMap = new Dictionary<int, int>();

        foreach(var n in employees) 
        {
            if (!employeeDataMap.ContainsKey(n[0])) employeeDataMap.Add(n[0], new Dictionary<int, int>());
            employeeDataMap[n[0]].Add(n[1], n[2]);

            if (!scoreMap.ContainsKey(n[1])) scoreMap.Add(n[1], n[2]);
        }

        var res = CalcScoreDFS(employeeDataMap, scoreMap, 0);
        
        return Math.Max(res[0], res[1]);
    }

    private static int[] CalcScoreDFS(Dictionary<int, Dictionary<int, int>> employeeDataMap, Dictionary<int, int> scoreMap, int currEmployeeId)
     {
        if(!employeeDataMap.ContainsKey(currEmployeeId)) 
        {
            return new [] {0, scoreMap[currEmployeeId]};
        }

        int[] res = new int[2]; //0 not include, 1 include
        var cache = new List<int[]>();

        foreach(var nei in employeeDataMap[currEmployeeId]) 
        {
            cache.Add(CalcScoreDFS(employeeDataMap, scoreMap, nei.Key));
        }

        foreach(var ele in cache) 
        {
            res[0] += Math.Max(ele[0], ele[1]); // not include
            res[1] += ele[0]; // include
        }

        int score = 0;
        res[1] += (scoreMap.TryGetValue(currEmployeeId, out score)) ? score : 0;

        return res;
    }

    // TODO: Fix it
    public static int[] MaxFunRecursive(
        List<List<int>> employees, 
        List<int> employeeData, 
        Dictionary<int, List<int>> employeeDataMap, 
        Dictionary<int, int> employeesScoreMap, 
        int[] score,
        bool tmp)
    {
        var currEmployeeId = employeeData[1];
        var managerId = employeeData[0];
        var employeeScore = employeeData[2];
        
        // base case : return
        if (!employeeDataMap.ContainsKey(currEmployeeId))
        {
            score[0] = GetScoresOfDirects(employees, employeeDataMap[managerId]); // invited: get sum of the score from Maneger's directs
            score[1] += employeeScore; // not invited: just add the sum of the directs
    
            return score;
        }
        
        // Recursive Call
        var currEmployeeDirects = tmp ? employeeDataMap[currEmployeeId] : employeeDataMap[managerId];
        foreach (var direct in currEmployeeDirects)
        {
            var directData = GetEmployeeData(employees, direct);
            score = MaxFunRecursive(employees, directData, employeeDataMap, employeesScoreMap, score, true);
        }
        
        return score;
    }
    private static List<int> GetEmployeeData(List<List<int>> employees, int employeeId)
    {
        foreach (var employeeData in employees)
        {
            if (employeeData[1] == employeeId) return employeeData;
        }
        return new List<int>();
    }

    private static int GetScoresOfDirects(List<List<int>> employees, List<int> directs)
    {
        var score = 0;
        foreach (var employeeId in directs)
        {
            var employeeData = GetEmployeeData(employees, employeeId);
            score += employeeData[2];
        }
        return score;
    }

    private static Dictionary<int, List<int>> GetDirectsMap(List<List<int>> employees)
    {
        var directsMap = new Dictionary<int, List<int>>();

        foreach (var employeeData in employees)
        {
            var empId = employeeData[1];
            var managerId = employeeData[0];
            if (directsMap.ContainsKey(managerId))
            {
                directsMap[managerId].Add(empId);
            }
            else
            {
                directsMap.Add(managerId, new List<int>{empId});
            }
        }

        return directsMap;
    }

    private static Dictionary<int, int> GetEmployeesScoreMap(List<List<int>> employees)
    {
        var employeesScoreMap = new Dictionary<int, int>();

        foreach (var employeeData in employees)
        {
            employeesScoreMap.Add(employeeData[1], employeeData[2]);
        }

        return employeesScoreMap;
    }

}
