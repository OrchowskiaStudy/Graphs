using Graphs.Models.BL.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Models.BL
{
    public class GraphContext : IObservable
    {
        private static GraphContext _instance;
        private readonly HashSet<IObserver> _clients = new HashSet<IObserver>();
        public static GraphContext Instance
        {
            get
            {
                if (_instance == null) { _instance = new GraphContext(); }
                return _instance;
            }
        }

        private GraphContext() { }

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
    }
}
