using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Vertices
{
    public class Vertex : IVertex
    {
        public string Id { get; private set; }
        public string Name { get; set; } = string.Empty;

        public Vertex()
        {
            Id = RandomNumberGenerator.Create().ToString();
        }

        public Vertex(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("cannot create vertex without id");
            }
            Id = id;
        }



        public override string ToString()
        {
            return $"Vertex: {Id}, Name: {Name}";
        }
    }
}
