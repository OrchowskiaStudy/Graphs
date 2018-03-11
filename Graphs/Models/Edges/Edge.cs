using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Edges
{
    public class Edge : IEdge
    {
        public string Id { get; }
        public int Weight { get; set; }
        public string Name { get; set; }

        public Edge()
        {
            Id = RandomNumberGenerator.Create().ToString();
        }

        public Edge(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("cannot create edge without id");
            }
            Id = id;
        }

        public override string ToString()
        {
            return $"Edge: {Id}, Name: {Name}";
        }
    }
}
