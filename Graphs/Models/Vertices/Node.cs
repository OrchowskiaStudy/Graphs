namespace Graphs.Models.Vertices
{
    public class Node
    {
        private const string EMPTY_MASK_VALUE = "_";
        private const string DEFAULT_VALUE = "0";
        private string _n;

        public string N { get { return _n; } set { _n = value == EMPTY_MASK_VALUE ? DEFAULT_VALUE : value; } }

        public Node(string val)
        {
            N = val;
        }
    }
}