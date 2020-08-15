using System;

namespace CTCI
{
    public class ChapterFour_TreesGraphs
    {
        /*
        4.3 Given a sorted increasing array, create a BST with minimal Heigh
        Complexity: N (Add method is doing bynary Search too: logN; but we discarted since N is Bigger)
        */
        public static BinarySearchTree CreateBSTFromArray(int[] sortedArray)
        {
            BinarySearchTree result = new BinarySearchTree();
            
            result.Add(sortedArray.Length/2);
            
            BuildNode(result, result.Root, 0, sortedArray.Length - 1);

            UpdateInOrder(result.Root, sortedArray);
            
            return result;
        }

        /*
        This function saves indexes instead of values
        Even though values are sorted the can be NOT consecutives (i.e: 9, 15, 500, 9999, 12345679)
        So, that's why my solution proposes to work with indexes
        Complexity: N
        */
        private static void BuildNode(BinarySearchTree result, BinaryNode node, int min, int max)
        {
            if (max - min <= 1) return;

            BinaryNode left = result.Add((node.Data - (node.Data - min) % 2) - ((node.Data - min) / 2));
            BinaryNode right = result.Add(node.Data + ((max - node.Data) % 2) + ((max - node.Data) / 2));
            BuildNode(result, left, min, node.Data);
            BuildNode(result, right, node.Data, max);
        }

        /*
        This function updates teh nodes' Data from indexes to real values
        Complexity: N
        */
        private static void UpdateInOrder(BinaryNode node, int[] sortedArray)
        {
            if (node == null) return;

            UpdateInOrder(node.L, sortedArray);
            node.Data = sortedArray[node.Data];
            UpdateInOrder(node.R, sortedArray);
        }
    }
}