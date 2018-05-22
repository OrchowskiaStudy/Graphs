using Graphs.Models.BL.Enumerations;
using Graphs.Models.Vertices;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Models.BL
{
    public class EulerCycleTypeVerifier
    {
        private const byte MAX_ODD_DEGREE_QUANTITY = 2;
        private const byte MIN_ODD_DEGREE_QUANTITY = 0;
        private const byte UNCONNECTED_VERTEX_DEGREE = 0;

        public EulerCycleResultType Verify(Dictionary<Vertex, byte> degrees)
        {
            byte oddDegrees = 0;
            if (!degrees.Any()) return EulerCycleResultType.Unknown;

            foreach (var degree in degrees.Values)
            {
                bool isUnconnected = degree == UNCONNECTED_VERTEX_DEGREE;
                if (isUnconnected) return EulerCycleResultType.NotExist;

                bool isOddAndExceedOddVerticesDegree = degree % 2 == 1 && ++oddDegrees > MAX_ODD_DEGREE_QUANTITY;
                if (isOddAndExceedOddVerticesDegree) return EulerCycleResultType.NotExist;
            }

            bool hasMaxDegreeForEulerTrack = oddDegrees == MAX_ODD_DEGREE_QUANTITY;
            if (hasMaxDegreeForEulerTrack) return EulerCycleResultType.Track;

            bool hasDegreeForEulerCycle = oddDegrees == MIN_ODD_DEGREE_QUANTITY;
            if (hasDegreeForEulerCycle) return EulerCycleResultType.Cycle;

            return EulerCycleResultType.NotExist;
        }
    }
}