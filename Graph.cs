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

        public static void GetShortestPathCostTest()
        {
            var graph = new Node[5];
            graph[0] = new Node(1, new List<Tuple<int, int>>() { new Tuple<int, int>(2, 10), new Tuple<int, int>(3, 7), new Tuple<int, int>(4, 9) });
            graph[1] = new Node(2, new List<Tuple<int, int>>() { new Tuple<int, int>(3, 1), new Tuple<int, int>(5, 6) });
            graph[2] = new Node(3, new List<Tuple<int, int>>() { new Tuple<int, int>(5, 11) });
            graph[3] = new Node(4, new List<Tuple<int, int>>() { new Tuple<int, int>(3, 8) });
            graph[4] = new Node(5, new List<Tuple<int, int>>());

            int cost;
            var path = GetShortestPathCost(graph, 5, out cost);
            foreach (var nodeId in path)
            {
                System.Console.WriteLine(nodeId);
            }
            System.Console.WriteLine("Cost: " + cost);
        }

        public class Node
        {
            public int NodeId {get; set;}
            public List<Tuple<int, int>> Neighbors {get; set;}

            public Node (int nodeId, List<Tuple<int, int>> neighbors)
            {
                NodeId = nodeId;
                Neighbors = neighbors;
            }
        }

        // Theory:  https://medium.com/basecs/finding-the-shortest-path-with-a-little-help-from-dijkstra-613149fbdc8e
        public static int[] GetShortestPathCost(Node[] graph, int end, out int cost) // graph = Node[] => NodeId and Neighbors (Node, cost)
        {
            var visited = new HashSet<int>();
            var unvisited = new HashSet<int>();
            var costTable = new Dictionary <int, Tuple<int, int>>(); // Key: Node, Value: [cost, parentNode]

            foreach (var n in graph)
            {
                unvisited.Add(n.NodeId);
                costTable.Add(n.NodeId, new Tuple<int, int>(int.MaxValue, n.NodeId));
            }

            foreach (var n in graph)
            {
                var currCost = costTable[n.NodeId].Item1 != int.MaxValue ? costTable[n.NodeId].Item1 : 0;

                foreach (var neighbor in n.Neighbors)
                {
                    if (visited.Contains(neighbor.Item1)) continue;

                    var neigId = neighbor.Item1;
                    var neigCost = neighbor.Item2;
                    var tmpCost = currCost + neigCost;

                    if (costTable[neigId].Item1 > tmpCost)
                    {
                        costTable[neigId] = new Tuple<int, int>(tmpCost, n.NodeId); // cost and parent
                    }
                }

                unvisited.Remove(n.NodeId);
                visited.Add(n.NodeId);
            }

            var path = new Stack<int>();
            path.Push(end);
            var parent = costTable[end];
            while (true)
            {
                path.Push(parent.Item2);
                parent = costTable[parent.Item2];
                
                if (path.Peek() == graph[0].NodeId) break;
            }
            var resultPath = new int[path.Count];
            var i = 0;
            while (path.Count > 0)
            {
                resultPath[i++] = path.Pop();
            }

            cost = costTable[end].Item1;
            return resultPath;
        }
    }
}