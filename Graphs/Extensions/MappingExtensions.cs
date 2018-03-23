using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Extensions
{
    public static class MappingExtensions
    {
        public static List<List<Node>> ToReferenceMatrix(this List<List<int>> matrix)
        {
            return matrix.Select(l => l.Select(v => new Node(v.ToString())).ToList()).ToList();
        }

        public static List<List<int>> ToNoReferenceMatrix(this List<List<Node>> matrix)
        {
            return matrix.Select(l => l.Select(v => int.Parse(v.N)).ToList()).ToList();
        }
    }
}
