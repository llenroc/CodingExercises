using System;
using System.Collections.Generic;
namespace InterviewCake
{
    

    public static class Zillow
    {
        public static void GetOptimalGasPurchaseTest()
        {
            var input = new List<GasInfo>() {
                new GasInfo('A', 5, 3),
                new GasInfo('B', 2, 3),
                new GasInfo('C', 6, 3),
                new GasInfo('D', 2, 4),
                new GasInfo('E', 4, 5),
            };

            var result = GetOptimalGasPurchase(input);

            foreach (var item in result)
            {
                Console.WriteLine("Gas: " + item.Key + " - Purchase $" + item.Value);
            }
        }

        public static Dictionary<Char, int> GetOptimalGasPurchase(List<GasInfo> input)
        {
            if (input == null || input.Count == 0)
            {
                throw new System.ArgumentException("input must have entries...");    
            }
            
            GasInfo lower = null;
            var result = new Dictionary<Char, int>();
            foreach (var entry in input)
            {
                if (lower == null || entry.Price < lower.Price)
                {
                    lower = entry;
                }
                
                var tmpPurchase = lower.Price * entry.Miles;
                
                if (result.ContainsKey(lower.GasId))
                {
                    result[lower.GasId] += tmpPurchase; 
                }
                else
                {
                    result.Add(entry.GasId, tmpPurchase); 
                }
            }
            
            return result;
        }

        public class GasInfo
        {
            public Char GasId { get; set; }
            public int Price { get; set; }
            public int Miles { get; set; }
            public GasInfo(Char gasId, int price, int miles)
            {
                Price = price;
                GasId = gasId;
                Miles = miles;
            }

        } 
    }

}