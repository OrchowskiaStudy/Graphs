using Graphs.Models.Vertices;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.Edges
{
    public class EdgeBase : IEdge
    {
        private IVertex _sourceVertex;
        private IVertex _destinationVertex;

        public string Id { get; }
        public int Weight { get; set; }
        public string Name { get; set; }

        

        public EdgeBase()
        {
            Id = RandomNumberGenerator.Create().ToString();
        }

        public EdgeBase(string id)
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

        //TODO: Implement validation to adding source
        public bool TryConfigureSource(IVertex source)
        {
            _sourceVertex = source;
            return true;
        }

        //TODO: Implement validation to adding destination
        public bool TryConfigureDestination(IVertex destination)
        {
            _destinationVertex = destination;
            return true;
        }
    }
}
