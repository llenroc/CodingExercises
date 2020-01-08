using System;
using System.Collections.Generic;

namespace InterviewCake
{
    public class BinaryTree
    {
        private static BinaryTreeNode CreateBinaryTree()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            var b = root.InsertRight(80);
            a.InsertLeft(10);
            a.InsertRight(40).InsertLeft(35).InsertLeft(32);
            b.InsertLeft(70);
            b.InsertRight(90).InsertLeft(85).InsertRight(87);

            return root;
        }
        public static void IsBalanceTest()
        {
            var root = CreateBinaryTree();
            Console.WriteLine(IsBalance(root));
        }

        public static void IsBSTTest()
        {
            var root = CreateBinaryTree();
            Console.WriteLine(IsBST(root));
        }


        public static void GetSecondLargestTest()
        {
            var root = CreateBinaryTree();
            Console.WriteLine(GetSecondLargest(root).Value);
        }

        public static BinaryTreeNode GetSecondLargest(BinaryTreeNode n)
        {
            if (n == null || (n.Right == null && n.Left == null))
            {
                throw new ArgumentException("Tree must have at least 2 nodes");
            }

            var curr = n;
            while (curr != null)
            {
                if (curr.Left != null && curr.Right == null)
                {
                    return GetLargest(curr.Left);
                }
                if (curr.Right != null && curr.Right.Right == null && curr.Right.Left == null)
                {
                    return curr;
                }
                curr = curr.Right;
            }
            return curr;
        }

        public static BinaryTreeNode GetLargest(BinaryTreeNode n)
        {
            if (n.Right == null)
            {
                return n;
            }
            return GetLargest(n.Right);
        }

        public static bool IsBST(BinaryTreeNode node)
        {
            if (node == null) return true;

            var s = new Stack<NodeBounds>();
            var tmp = new NodeBounds(node, int.MinValue, int.MaxValue);

            s.Push(tmp);
            while (s.Count > 0)
            {
                var n = s.Pop();

                if (n.Node.Value <= n.LowerBound || n.Node.Value >= n.UpperBound)
                {
                    return false;
                }
                if (n.Node.Right != null) 
                {
                    s.Push(new NodeBounds(n.Node.Right, n.Node.Value, n.UpperBound));
                }
                if (n.Node.Left != null)
                {
                    s.Push(new NodeBounds(n.Node.Left, n.LowerBound, n.Node.Value));
                }
            }

            return true;
        }

        public static bool IsBalance(BinaryTreeNode node)
        {
            if (node == null) return true;

            var levels = new List<int>();
            var s = new Stack<Tuple<BinaryTreeNode, int>>();
            
            var leafLevel = 0;
            s.Push(new Tuple<BinaryTreeNode, int>(node, leafLevel));
            while (s.Count > 0)
            {
                var n = s.Pop();
                if (n.Item1.Right == null && n.Item1.Left == null)
                {
                    if (!levels.Contains(n.Item2))
                    {
                        levels.Add(n.Item2);
                    }
                    if (levels.Count > 2 ||
                        (levels.Count == 2 && Math.Abs(levels[0] - levels[1]) > 1)) 
                    {
                            return false;
                    }
                }
                if (n.Item1.Right != null) 
                {
                    s.Push(new Tuple<BinaryTreeNode, int>(n.Item1.Right, n.Item2 + 1));
                }
                if (n.Item1.Left != null)
                {
                    s.Push(new Tuple<BinaryTreeNode, int>(n.Item1.Left, n.Item2 + 1));
                }
            }
            return true;
        }
    }

    // This class is NOT provided. Is part of the solution fot the BST exercise
    public class NodeBounds
    {
        public BinaryTreeNode Node { get; }

        public int LowerBound { get; }

        public int UpperBound { get; }

        public NodeBounds(BinaryTreeNode node, int lowerBound, int upperBound)
        {
            Node = node;
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
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