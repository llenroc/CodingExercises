using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCake
{
    public class Graph
    {
        public class GraphNode
        {
            public string Label { get; }
            public ISet<GraphNode> Neighbors { get; }
            public string Color { get; set; }
            public bool HasColor { get { return Color != null; } }

            public GraphNode(string label)
            {
                Label = label;
                Neighbors = new HashSet<GraphNode>();
            }

            public void AddNeighbor(GraphNode neighbor)
            {
                Neighbors.Add(neighbor);
            }
        }

        public static void ColorGraph(GraphNode[] graph, String[] colors)
        {
            // Create a valid coloring for the graph
            if (graph == null || graph.Length == 0) 
                throw new System.ArgumentException();
            
            foreach (var n in graph)
            {
                if (n.Neighbors == null)
                    continue;
                    
                if (n.Neighbors.Contains(n)) throw new System.ArgumentException();
                
                var ilegal = new HashSet<string>();
                foreach (var tmp in n.Neighbors)
                {
                    ilegal.Add(tmp.Color);
                }
                
                var legal = String.Empty;
                foreach (var c in colors)
                {
                    if (!ilegal.Contains(c))
                    {
                        legal = c;
                        break;
                    }
                }
                
                n.Color = legal;
            }
        }

        public static string[] GetMeshMessagePath(Dictionary<String, String[]> graph, string startNode, string endNode)
        {
            if (graph == null || graph.Count == 0) return null;
            if (!graph.ContainsKey(startNode) || !graph.ContainsKey(endNode))
                throw new System.ArgumentException();

            var howToReach = new Dictionary<string, string>();
            var q = new Queue<string>();
            q.Enqueue(startNode);
            howToReach.Add(startNode, null);
            
            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (n == endNode)
                {
                    var result = new List<string>();
                    var tracker = endNode;
                    while (tracker != null)
                    {
                        result.Add(tracker);
                        tracker = howToReach[tracker];
                    }
                    result.Reverse();
                    return result.ToArray();
                }
                
                foreach (var subNode in graph[n])
                {
                    if (!howToReach.ContainsKey(subNode))
                    {
                        howToReach.Add(subNode, n);
                        q.Enqueue(subNode);
                    }
                }
            }
            
            return null;
        }

        // Theory:  https://medium.com/basecs/finding-the-shortest-path-with-a-little-help-from-dijkstra-613149fbdc8e
        public static int GetShortestPathCost()
        {
            return -1;
        }
    }
}