using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Models.BL
{
    public class GraphContext : IObserverable
    {
        private static int _vertexCount = 0;
        public static int VertexCount { get { return ++_vertexCount; } }
        private static int _edgeCount = 0;
        public static int EdgeCount { get { return ++_edgeCount; } }
        private static GraphContext _instance;
        private readonly HashSet<IObserver> _clients = new HashSet<IObserver>();

        public List<Vertex> Vertices { get; private set; } = new List<Vertex>();
        public List<Edge> Edges { get; private set; } = new List<Edge>();

        public static GraphContext Instance
        {
            get
            {
                if (_instance == null) { _instance = new GraphContext(); }
                return _instance;
            }
        }

        private GraphContext()
        {
        }

        public static void ClearEdges()
        {
            _edgeCount = 0;
            Instance.Edges.Clear();
        }

        public static void ClearVertices()
        {
            _vertexCount = 0;
            Instance.Vertices.Clear();
        }

        public void Add(IObserver observer)
        {
            _clients.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            if (_clients.Contains(observer))
            {
                _clients.Remove(observer);
            }
        }

        public void RemoveAll()
        {
            _clients.Clear();
        }

        public void NotifyObservers(IObserver except)
        {
            _clients.Where(observer => observer != except).ToList().ForEach(item => item.Notify());
        }
    }
}