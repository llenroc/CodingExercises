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

        // Phone Screen
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

        // On Site
        public static void IsBSTTest()
        {
            /*
                    10
                  /    \
                5       15
               /  \     /
              3    7   13
                  /   /
                 6   11
            */
            var root = new BinaryTreeNode(10);
            var a = root.InsertLeft(5);
            var b = root.InsertRight(15);
            a.InsertLeft(3);
            a.InsertRight(7).InsertLeft(6);
            b.InsertLeft(13).InsertLeft(11);

            System.Console.WriteLine(IsBST(root));
        }

        public static bool IsBST(BinaryTreeNode root)
        {
            if (root == null) return true;

            return InOrder(root, new Stack<int>());
        }

        private static bool InOrder(BinaryTreeNode n, Stack<int> s)
        {
            if (n == null) return true;

            if (!InOrder(n.Left, s)) return false;
            
            if (s.Count > 0)
            {
                if (s.Peek() > n.Value) return false;
                s.Pop();
            }
            s.Push(n.Value);
            
            if (!InOrder(n.Right, s)) return false;

            return true;
        }

        
        // This class is provided in the exercises
        public class BinaryTreeNode
        {
            public int Value { get; }
            public BinaryTreeNode Left { get; private set; }
            public BinaryTreeNode Right { get; private set; }

            public BinaryTreeNode(int value)
            {
                Value = value;
            }

            public BinaryTreeNode InsertLeft(int leftValue)
            {
                Left = new BinaryTreeNode(leftValue);
                return Left;
            }

            public BinaryTreeNode InsertRight(int rightValue)
            {
                Right = new BinaryTreeNode(rightValue);
                return Right;
            }
        }
    }

}