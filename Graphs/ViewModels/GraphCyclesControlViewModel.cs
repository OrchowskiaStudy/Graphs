using Graphs.Models.BL;
using Graphs.Models.BL.Enumerations;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System.Collections.Generic;

namespace Graphs.ViewModels
{
    public class GraphCyclesControlViewModel : ViewModelBase
    {
        private readonly Dictionary<EulerCycleResultType, string> _eulerCycleTypeTranslationMapping = new Dictionary<EulerCycleResultType, string>()
        {
            { EulerCycleResultType.Unknown, "EulerCycleUnknown" },
            { EulerCycleResultType.Track, "EulerTrack" },
            { EulerCycleResultType.Cycle, "EulerCyle" },
            { EulerCycleResultType.NotExist, "EulerCycleNotExist" }
        };

        private readonly Dictionary<HamiltonCycleType, string> _hamiltonCycleTypeTranslationMapping = new Dictionary<HamiltonCycleType, string>()
        {
            { HamiltonCycleType.Unknown, "HamiltonCycleUnknown" },
            { HamiltonCycleType.Cycle, "HamiltonCyle" },
            { HamiltonCycleType.NotExist, "HamiltonCycleNotExist" }
        };

        public string EulerCycleType { get { return _eulerCycleTypeTranslationMapping[_eulerCycleType]; } }
        public string EulerCycle { get; set; }

        public string HamiltonCycleResultType { get { return _hamiltonCycleTypeTranslationMapping[_hamiltonCycleType]; } }
        public string HamiltonCycle { get; set; }

        private EulerCycleResultType _eulerCycleType;
        private HamiltonCycleType _hamiltonCycleType;
        private List<Vertex> Vertices = GraphContext.Instance.Vertices;
        private List<Edge> Edges = GraphContext.Instance.Edges;

        public RelayCommand FindEulerCycleCommand => new RelayCommand((param) =>
        {
            VertexDegreeComputer computer = new VertexDegreeComputer(Edges, Vertices);
            Dictionary<Vertex, byte> degrees = computer.Compute();
            _eulerCycleType = new EulerCycleTypeVerifier().Verify(degrees);
            EulerCycle = new EulerCycleFinder().Find(degrees, Edges, _eulerCycleType);
            OnPropertyChanged(nameof(EulerCycleType));
            OnPropertyChanged(nameof(EulerCycle));
        });

        public RelayCommand FindHamiltonCycleCommand => new RelayCommand((param) =>
        {
            VertexDegreeComputer computer = new VertexDegreeComputer(Edges, Vertices);
            Dictionary<Vertex, byte> degrees = computer.Compute();
            _hamiltonCycleType = new HamiltonCycleTypeVerifier().Verify(degrees);
            HamiltonCycle = new HamiltonCycleFinder().Find(degrees, Edges, _hamiltonCycleType);
            _hamiltonCycleType = !string.IsNullOrEmpty(HamiltonCycle) ? HamiltonCycleType.Cycle : HamiltonCycleType.NotExist;
            OnPropertyChanged(nameof(HamiltonCycleResultType));
            OnPropertyChanged(nameof(HamiltonCycle));
        });
    }
}