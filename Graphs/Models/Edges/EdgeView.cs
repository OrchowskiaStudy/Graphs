using Graphs.Models.BL;
using Graphs.Models.Vertices;
using QuickGraph;
using System;

namespace Graphs.Models.Edges
{
    public class Edge : Edge<Vertex>, IComparable<Edge>
    {
        public int Number { get; private set; }
        public string Id { get; private set; }
        public int Weight { get; set; } = 1;

        public Edge(string id, Vertex source, Vertex target) : base(source, target)
        {
            Number = GraphContext.EdgeCount;
            Id = Number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge edge)
            {
                return edge.Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17 * 23 + Id.GetHashCode();
                return hash;
            }
        }
        public int CompareTo(Edge other)
        {
            return Number.CompareTo(other.Number);
        }
    }
}