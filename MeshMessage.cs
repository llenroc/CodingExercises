using System;
using System.Collections.Generic;

namespace InterviewCake
{
    public static class MeshMessage
    {
        public static string[] GetPath(Dictionary<String, String[]> graph,
            string startNode, string endNode)
        {
            if (!graph.ContainsKey(startNode))
            {
                throw new ArgumentException();
            }
            if (!Contains(graph, startNode))
            {
                throw new ArgumentException();
            }            
            if (endNode == startNode)
            {
                return new [] {endNode};
            }
            
            return getPath(graph, startNode, endNode);
        }

        private static bool Contains(Dictionary<String, String[]> graph, string endNode)
        {
            foreach (KeyValuePair<string, string[]> entry in graph)
            {
                HashSet<string> connections = new HashSet<string>(entry.Value);
                if (connections.Contains(endNode))
                {
                    return true;
                }
            }
        
            return false;
        }
        
        private static string[] getPath(Dictionary<String, String[]> graph,
            string startNode, string endNode)
        {
            if (endNode == startNode)
            {
                return new [] {endNode};
            }
            
            // string parent = null;
            HashSet<string> visitedUsers = new HashSet<string>();
            Dictionary<string, string> path = new Dictionary<string, string> {{startNode, null}};
            Queue<string> userNames = new Queue<string>();
            userNames.Enqueue(startNode);

            while (userNames.Count > 0)
            {
                string userName = userNames.Dequeue();
                visitedUsers.Add(userName);

                string[] children = graph[userName];
                if (children != null && children.Length > 0)
                {
                    foreach (string childUserName in children)
                    {
                        if (visitedUsers.Contains(childUserName) || childUserName == startNode)
                        {
                            continue;
                        }

                        userNames.Enqueue(childUserName);
                        path.Add(childUserName, userName);
                        visitedUsers.Add(childUserName);

                        // destination user is found
                        if (childUserName == endNode)
                        {
                            return GetTargetPath(endNode, path);
                        }
                    }
                }
            }

            return null;
        }

        private static string[] GetTargetPath(string endNode, Dictionary<string, string> path)
        {
            var response = new List<string> { endNode };
            string connectedUser = path[endNode];
            while (connectedUser != null) // Parent
            {
                response.Insert(0, connectedUser);
                connectedUser = path[connectedUser];
            }
            return response.ToArray();
        }
    }
}