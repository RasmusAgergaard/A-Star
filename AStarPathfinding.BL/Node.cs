using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathfinding.BL
{
    class Node
    {
        public enum nodeState { untestet, open, closed}

        public Point Location { get; private set; }
        public bool IsWalkable { get; set; }
        public float G { get; private set; }
        public float H { get; private set; }
        public float F { get { return G + H; } }
        public nodeState State { get; set; }
        public Node ParentNode { get; set; }

    }
}
