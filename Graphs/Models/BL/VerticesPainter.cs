using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Windows.Media.Brushes;

namespace Graphs.Models.BL
{
    public class VerticesPainter
    {
        private readonly List<Vertex> _vertices;
        private readonly List<Edge> _edges;
        private List<Brush> brushes = new List<Brush>()
        {
            Black,
            LightBlue,
            Green,
            Blue,
            LightGreen,
            Yellow,
            LightYellow,
            Red,
            Magenta,
            DarkCyan
        };

        public VerticesPainter(List<Vertex> vertices, List<Edge> edges)
        {
            _vertices = vertices;
            _edges = edges;
        }

        public void MakeYourLifeMoreColorfull()
        {
            _vertices.ForEach(v => v.CustomColor = null);
            var vertices = new List<Vertex>(_vertices);
            var families = new VertexFamilyFactory(_edges).CreateFamilies(vertices).ToList();
            foreach (var family in families)
            {
                var childrenColors = family.Childrens.Where(x => x.CustomColor != null).Select(x => x.CustomColor);
                family.Parent.CustomColor = brushes.FirstOrDefault(x => !childrenColors.Contains(x)) ?? throw new ArgumentException("Give me more colors!!!");
            }
        }
    }
}
