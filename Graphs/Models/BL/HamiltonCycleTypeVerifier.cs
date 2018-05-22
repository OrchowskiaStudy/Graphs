using Graphs.Models.BL.Enumerations;
using Graphs.Models.Vertices;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Models.BL
{
    public class HamiltonCycleTypeVerifier
    {
        private const byte UNCONNECTED_VERTEX_DEGREE = 0;

        public HamiltonCycleType Verify(Dictionary<Vertex, byte> degrees)
        {
            if (!degrees.Any()) return HamiltonCycleType.Unknown;

            foreach (var degree in degrees.Values)
            {
                bool isUnconnected = degree == UNCONNECTED_VERTEX_DEGREE;
                if (isUnconnected) return HamiltonCycleType.NotExist;
            }
            return HamiltonCycleType.Unknown;
        }
    }
}