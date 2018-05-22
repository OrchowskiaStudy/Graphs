using Graphs.Models.BL.Enumerations;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Models.BL
{
    /// <summary>
    /// Fleury's algorithm implementation
    /// more info at https://pl.wikipedia.org/wiki/Algorytm_Fleury%E2%80%99ego
    /// </summary>
    public class EulerCycleFinder
    {
        private const string LIST_SEPARATOR = "⬌";
        private const byte ISOLATED_DEGREE = 0;

        private EulerCycleResultType[] _unsupportedTypes = new EulerCycleResultType[]
        {
            EulerCycleResultType.Track,
            EulerCycleResultType.NotExist,
            EulerCycleResultType.Unknown
        };

        /// <summary>
        /// REFACTOR NEEDED @#$%@$%^&#%^&*@$#@
        /// it's late, i'm tired, i don't care - but it's crap :/
        /// </summary>
        public string Find(Dictionary<Vertex, byte> degrees, List<Edge> edges, EulerCycleResultType type)
        {
            if (ValidateType(type)) { return string.Empty; }
            Stack<KeyValuePair<Vertex, byte>> stack = new Stack<KeyValuePair<Vertex, byte>>();
            List<KeyValuePair<Vertex, byte>> solution = new List<KeyValuePair<Vertex, byte>>();
            List<Edge> edgesCopy = new List<Edge>(edges);
            var analyzedVertex = degrees.FirstOrDefault();
            solution.Add(analyzedVertex);
            while (true)
            {
                while (analyzedVertex.Value != ISOLATED_DEGREE)
                {
                    KeyValuePair<Edge, KeyValuePair<Vertex, byte>> incident = FindIncident(degrees, edgesCopy, analyzedVertex.Key);
                    if (incident.Key == null) break;
                    stack.Push(analyzedVertex);
                    edgesCopy.Remove(incident.Key);
                    analyzedVertex = incident.Value;
                }

                if (stack.Any())
                {
                    analyzedVertex = stack.Pop();
                    solution.Add(analyzedVertex);
                }
                else
                {
                    break;
                }
            }
            return string.Join(LIST_SEPARATOR, solution.Select(x => x.Key.Id));
        }

        private KeyValuePair<Edge, KeyValuePair<Vertex, byte>> FindIncident(Dictionary<Vertex, byte> degrees, List<Edge> edges, Vertex vertex)
        {
            Vertex incidentVertex;
            var e = edges.FirstOrDefault(edge => edge.Source == vertex);
            incidentVertex = e?.Target;
            if (e == null)
            {
                e = edges.FirstOrDefault(edge => edge.Target == vertex);
                incidentVertex = e?.Source;
            }
            return new KeyValuePair<Edge, KeyValuePair<Vertex, byte>>(e, degrees.FirstOrDefault(i => i.Key == incidentVertex));
        }

        private bool ValidateType(EulerCycleResultType type)
        {
            return _unsupportedTypes.Contains(type);
        }
    }
}