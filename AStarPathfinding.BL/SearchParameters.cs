using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathfinding.BL
{
    public class SearchParameters
    {
        private int width = 7;
        private int height = 5;

        //bool[,] grid = new bool[7, 5];

        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public bool[,] Map { get; set; }

        private bool Search(Node currentNode)
        {
            currentNode.State = Node.nodeState.closed;
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));

            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == this.endNode.Location)
                {
                    return true;
                }
                else
                {
                    if (Search(nextNode))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = new List<Node>();
            IEnumerable<Point> nextLocations = GetAdjacentLocations(fromNode.Location);

            foreach (var location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                if (x < 0 || x >= width || y < 0 || y >= height)
                {
                    continue;
                }

                Node node = nodes[x, y];

                if (!node.IsWalkable)
                {
                    continue;
                }

                if (node.State == Node.nodeState.closed)
                {
                    continue;
                }

                if (node.State == Node.nodeState.open)
                {
                    float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
                    float gTemp = fromNode.G + traversalCost;
                    if (gTemp < node.G)
                    {
                        node.ParentNode = fromNode;
                        walkableNodes.Add(node);
                    }
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = Node.nodeState.open;
                    walkableNodes.Add(node);
                }
            }

            return walkableNodes;
        }

        public List<Point> FindPath()
        {
            List<Point> path = new List<Point>();
            bool success = Search(startNode);
            if (success)
            {
                Node node = this.endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }
                path.Reverse();
            }
            return path;
        }
    }
}
