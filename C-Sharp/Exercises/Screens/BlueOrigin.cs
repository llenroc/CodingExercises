using System;
using System.Collections.Generic;

namespace Exercises
{
    public class BlueOrigin
    {
        public static List<TreeNode> GetDiffNodes(TreeNode a, TreeNode b)
        {
            if (a.Data != b.Data) return new List<TreeNode>() { a, b };

            Queue<TreeNode> qa = new Queue<TreeNode>();
            qa.Enqueue(a);
            Queue<TreeNode> qb = new Queue<TreeNode>();
            qb.Enqueue(b);
            
            List<TreeNode> result = new List<TreeNode>();
            
            while (qa.Count > 0)
            {
                HashSet<int> differentChildren = CompareChildren(qa.Peek().Children, qb.Peek().Children);
                ProcessChildren(qa, differentChildren, result);
                ProcessChildren(qb, differentChildren, result);
            }

            return result;
        }

        private static void ProcessChildren(Queue<TreeNode> q, HashSet<int> differentChildren, List<TreeNode> result)
        {
            foreach (var item in q.Dequeue().Children)
            {
                if (!differentChildren.Contains(item.Data))
                    q.Enqueue(item);
                else
                    result.Add(item);
            }
        }

        private static HashSet<int> CompareChildren(List<TreeNode> a_children, List<TreeNode> b_children)
        {
            HashSet<int> differentChildren = new HashSet<int>();

            foreach (var item in a_children) differentChildren.Add(item.Data);
            
            foreach (var item in b_children)
            {
                if (!differentChildren.Contains(item.Data))
                    differentChildren.Add(item.Data);
                else
                    differentChildren.Remove(item.Data);
            }

            return differentChildren;
        }

    }


    public class TreeNode
    {
        public List<TreeNode> Children { get; set; }

        public int Data { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Children = new List<TreeNode>();
        }
    }

}