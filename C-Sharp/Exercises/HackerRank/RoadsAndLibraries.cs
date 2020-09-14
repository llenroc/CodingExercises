using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class RoadsAndLibraries
    {
        public static long GetRoadsAndLibraries(int n, int c_lib, int c_road, int[][] cities) {
            List<HashSet<int>> connectedCitiesList = new List<HashSet<int>>();
            Array.Sort(cities,  new Comparison<int[]>( 
                (x,y) => { return x[1] < y[1] ? -1 : (x[1] > y[1] ? 1 : 0); }
            ));
            foreach (int[] pair in cities)
            {
                if (pair == null) break;

                if (connectedCitiesList.Count == 0)
                {
                    connectedCitiesList.Add(new HashSet<int>() { pair[0], pair[1]});
                    continue;
                }

                foreach (HashSet<int> connectedCities in connectedCitiesList)
                {
                    if (connectedCities.Contains(pair[0]) || connectedCities.Contains(pair[1]))
                    {
                        connectedCities.Add(pair[0]);
                        connectedCities.Add(pair[1]);
                    }
                    else
                    {
                        connectedCitiesList.Add(new HashSet<int>() { pair[0], pair[1]});
                        break;
                    }
                }
            }

            int libraryCost = 0;
            int roadCost = 0;
            int isolatedCities = n;
            foreach (HashSet<int> connectedCities in connectedCitiesList)
            {
                libraryCost += c_lib;
                roadCost += c_road * (connectedCities.Count - 1);
                isolatedCities -= connectedCities.Count;
            }
            libraryCost += isolatedCities * libraryCost;
        
            long result = Math.Min(libraryCost + roadCost, n * c_lib);

            return result;
        }

    }
}