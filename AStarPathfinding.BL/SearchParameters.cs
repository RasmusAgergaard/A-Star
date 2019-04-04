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
        //bool[,] grid = new bool[7, 5];

        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public bool[,] Map { get; set; }

        private bool Search(Node currentNode)
        {
            return false;
        }
    }
}
