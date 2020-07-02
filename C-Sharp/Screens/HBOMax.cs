using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.

namespace InterviewCake
{
    // Often, tasks have dependencies before they can be completed.  This can be true in real life projects, or in software projects.
    // Because of the dependency between tasks, you may have to work on them in a specific order.
    //
    // Given a list of pairs of (<task>, <prerequisite task>), determine a valid build order.
    // Write a method that returns an valid build order that satisfies the dependency list.
    //
    // [ [Logging, Memory],[Apex, Database], [Database, Logging], [Apex, Logging], [Logging, IO] ]

    /*  
        IO
        Memory
            Logging
                Database
                    Apex

                root
                 |
                Apex
                 |
                 DB
                 |
                log
               /  \
             mem    IO

    */
    class HBOMax
    {
        public class Node
        {
            public string Lib {get; set;}
            public Dictionary<string, Node> Deps {get; set;}
        
            public Node(string lib)
            {
                Lib = lib;
                Deps = new Dictionary<string, Node>();
            }
        }

        public static List<string> GetBuildOrder(string[][] libs)
        {
            Node root = null;
            var result = new List<string>();

            for (var i = 0 ; i < libs.Length; i++)
            {
                var lib = libs[i][0];
                var dep = libs[i][1];
                if (root == null && root.Deps == null)
                {
                    root = new Node(null);
                    root.Deps.Add(lib, new Node(dep));
                    continue;
                }

                // insert lib if not exist
                Node parent = null;
                var libNode = GetNodeWithParent(lib, out parent);
                if (libNode == null) root.Deps.Add(lib, null);
                libNode = GetNodeWithParent(lib, out parent);
                
                var depNode = GetNodeWithParent(dep, out parent);
                // If Dep already exists in a upper level then move reference
                if (depNode != null && !IsDepFoundDownBellow(libNode)) parent.Deps.Remove(dep);
                // insert dep. 
                libNode.Deps.Add(dep, null);
            }

            TraverseGraph(root, result);

            return result;
        }

        private static Node GetNodeWithParent(string toFind, out Node parent)
        {
            parent = null;

            return null;
        }

        private static bool IsDepFoundDownBellow(Node curr)
        {
            return true;
        }

        private static List<string> TraverseGraph(Node n, List<string> r)
        {
            // PostOrder Traversal
            return null;
        }


        // public static List<string> GetBuildOrder(string[][] libs)
        // {
        //     var result = new List<string>();
            
        //     // build graph
        //     var root = new Node(null);
        //     for(var i = 0; i < libs.Length; i++)
        //     {
        //         var lib = libs[i][0];
        //         var dep = libs[i][1];
                
        //         var libNode = GeNode(root, lib);
        //         if (libNode == null)
        //         {
        //             root.Value.Add(new Node(lib));
        //             libNode = GeNode(root, lib);
        //         }
        //         libNode.Value.Add(new Node(dep));
        //     }       
        
        //     PostOrder(root, result);
            
        //     return result;
        // }
        
        // private static Node GetNode(Node n, string lib)
        // {
        //     if (n.Value == null) return null;
            
        //     foreach (var child in n.Value)
        //     {
        //         if(child == lib) return child;    
        //         n = GetNode(child, lib);
        //     }
            
        //     return n;
        // }
            
        // private static void PostOrder(Node n, List<string> list)
        // {
        //     if (n == null) return;
            
        //     foreach(var child in n.Value)
        //     {
        //         list.Add(child);
        //         PostOrder(child, list);
        //     }
        //     PostOrder(n, list);
        // }
        
        // public class Node
        // {
        //     public string Node {get; set;}
        //     public List<Node> Value {get; set;}
        
        //     public Node(string n)
        //     {
        //         Node = n;
        //         Value = new List<Node>();
        //     }
        // }
    }
}