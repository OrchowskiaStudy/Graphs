using Graphs.Models.BL;
using Graphs.Models.BL.Observer;
using Graphs.Models.Edges;
using Graphs.Models.Vertices;
using Graphs.Views.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.ViewModels
{
    public class AdiacencyMatrixInputViewModel : ViewModelBase, IObserver
    {
        public List<List<MyString>> Matrix { get; set; }
        private AdiacencyMatrix adiacencyMatrix = new AdiacencyMatrix();
        public AdiacencyMatrixInputViewModel()
        {
            GraphContext.Instance.Add(this);
            Matrix = ToReferenceMatrix(adiacencyMatrix.ToMatrix());
            OnPropertyChanged(nameof(Matrix));

        }

        public void Notify()
        {
            Matrix = ToReferenceMatrix(adiacencyMatrix.ToMatrix());
            OnPropertyChanged(nameof(Matrix));
        }

        private List<List<MyString>> ToReferenceMatrix(List<List<int>> matrix)
        {
            return matrix.Select(l => l.Select(v => new MyString(v.ToString())).ToList()).ToList();
        }

        private List<List<int>> ToNoReferenceMatrix(List<List<MyString>> matrix)
        {
            return matrix.Select(l => l.Select(v => int.Parse(v.N)).ToList()).ToList();
        }

        public RelayCommand MatrixValueChanged => new RelayCommand((sender) =>
        {
            adiacencyMatrix.UpdateContext(ToNoReferenceMatrix(Matrix));
        });


        public class MyString
        {
            public string N { get; set; }
            public MyString(string val)
            {
                N = val;
            }
        }
    }
}