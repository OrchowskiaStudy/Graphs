using Graphs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Views.Models
{
    public class VertexView : ViewModelBase
    {
        public string Id { get; set; }
        public Guid Uid { get; private set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public VertexView(string id, string name = "")
        {
            Id = id;
            Name = name;
            Uid = Guid.NewGuid();
        }
    }
}
