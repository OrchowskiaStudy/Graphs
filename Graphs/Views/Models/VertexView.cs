using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Views.Models
{
    public class VertexView
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public VertexView(string id, string name = "")
        {
            Id = id;
            Name = name;
        }
    }
}
