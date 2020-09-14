using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class JourneyToMoon
    {
        public static int GetJourneyToMoonCombo(int n, int[][] astronaut) {
            List<int[]> idsPerCountry = GetIdsPerCountry(n, astronaut);

            int result = 0;
            int sum = 0;
            foreach(int[] item in idsPerCountry)
            {
                int size = item.Length;
                result += sum * size;
                sum += size;    
            }   
            return result;
        }

        private static List<int[]> GetIdsPerCountry(int n, int[][] astronautPair)
        {
            HashSet<int> ids = new HashSet<int>();
            for (int i = 0; i < n; i++) ids.Add(i);

            List<HashSet<int>> astronautsIdsPerCountry = new List<HashSet<int>>();

            foreach (int[] pair in astronautPair)
            {
                if (astronautsIdsPerCountry.Count == 0)
                {
                    astronautsIdsPerCountry.Add(new HashSet<int>() { pair[0], pair[1] });
                    ids.Remove(pair[0]);
                    ids.Remove(pair[1]);
                    continue;
                }

                bool isIdFound = false;
                foreach (HashSet<int> countryIds in astronautsIdsPerCountry)
                {
                    if (countryIds.Contains(pair[0]) || countryIds.Contains(pair[1]))
                    {
                        countryIds.Add(pair[0]);
                        countryIds.Add(pair[1]);
                        isIdFound = true;
                        break;
                    }
                }
                
                if (!isIdFound) astronautsIdsPerCountry.Add(new HashSet<int>() { pair[0], pair[1] });
                
                ids.Remove(pair[0]);
                ids.Remove(pair[1]);
            }

            List<int[]> result = new List<int[]>();
            foreach (HashSet<int> countryIds in astronautsIdsPerCountry) result.Add(countryIds.ToArray());
            
            foreach (int id in ids) result.Add(new int[] { id } );

            return result;
        }

        private static int GetPairCombosDiffCountry(List<int[]> idsPerCountry)
        {
            int result = 0;
            int ini = -1;
            foreach (var item in idsPerCountry)
            {
                if (ini == -1)
                {
                    ini = item.Length;
                    continue;
                }
                
                result += ini * item.Length;
            }
            return result;
        }
    }
}