using System;
using System.Collections.Generic;

namespace CTCI
{
    public class BinarySearchTree
    {
        public BinaryNode Root { get; set; }

        public BinaryNode Add(int value)
        {
            BinaryNode parent = this.Root;
            BinaryNode curr = this.Root;
            // If Tree is not null
            while (curr != null)
            {
                parent = curr;
                if (value < curr.Data)
                    curr = curr.L; 
                else if (value > curr.Data)
                    curr = curr.R;
                else
                    return curr;
            }
    
            // Value is New OR Tree/Root is Null 
            BinaryNode newNode = new BinaryNode(value);
            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < parent.Data)
                    parent.L = newNode;
                else
                    parent.R = newNode;
            }
            return newNode;
        }

        // This class is provided in the exercises

    }

    public class BinaryNode
    {
        public int Data { get; set;}
        public BinaryNode L { get; set;}
        public BinaryNode R { get; set; }

        public BinaryNode(int value)
        {
            Data = value;
        }
    }
}