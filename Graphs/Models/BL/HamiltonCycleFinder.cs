using Graphs.Models.BL.Enumerations;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class HamiltonCycleFinder
    {
        private const string LIST_SEPARATOR = "⬌";
        private List<List<Vertex>> _solutions = new List<List<Vertex>>();
        public string Find(Dictionary<Vertex, byte> degrees, List<Edge> edges, HamiltonCycleType type)
        {
            if (edges.Count < 3 || type == HamiltonCycleType.NotExist)
            {
                return string.Empty;
            }
            Vertex startVertex = degrees.FirstOrDefault().Key;
            var edgesCopy = new List<Edge>(edges);
            var solution = new List<Vertex>();
            _solutions.Add(solution);
            Procedure(startVertex, edgesCopy, degrees.Keys.ToList(), solution);
            //
            var results = _solutions.Where(s => edges.Where(e=> ((s.First() == e.Source && s.Last() == e.Target) || (s.First() == e.Target && s.Last() == e.Source))&& degrees.Count == s.Count).Any()).ToList();
            if (results.Any())
            {
                var result = results.FirstOrDefault();
                return string.Join(LIST_SEPARATOR, result.Select(x => x.Id)) + LIST_SEPARATOR + result.First().Id;
            }
            return string.Empty;
        }

        private void Procedure(Vertex startVertex, List<Edge> edges, List<Vertex> vertexes, List<Vertex> solution)
        {
            if (solution.Contains(startVertex)) { return; }
            solution.Add(startVertex);
            var targets = edges.Where(e => e.Source == startVertex && !solution.Contains(e.Target)).ToList();
            var sources = edges.Where(e => e.Target == startVertex && !solution.Contains(e.Source)).ToList();
            if (!targets.Any() && !sources.Any()) { return; }
            if (targets.Count + sources.Count > 1)
            {
                targets.ForEach(i =>
                {
                    var edgesCopy = edges.ToList();
                    edgesCopy.Remove(i);
                    var solutionCopy = solution.ToList();
                    _solutions.Add(solutionCopy);
                    Procedure(i.Target, edgesCopy, vertexes, solutionCopy);
                });

                sources.ForEach(i =>
                {
                    var edgesCopy = edges.ToList();
                    edgesCopy.Remove(i);
                    var solutionCopy = solution.ToList();
                    _solutions.Add(solutionCopy);
                    Procedure(i.Source, edgesCopy, vertexes, solutionCopy);
                });
                return;
            }
            Vertex next = targets.Select(i => i.Target).Concat(sources.Select(i => i.Source)).FirstOrDefault();
            edges.Remove(targets.Concat(sources).First());
            Procedure(next, edges, vertexes, solution);
        }
    }
}
