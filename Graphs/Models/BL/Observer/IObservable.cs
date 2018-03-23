namespace Graphs.Models.BL.Observer
{
    public interface IObserverable
    {
        void NotifyObservers(IObserver except);

        void Add(IObserver observer);

        void Remove(IObserver observer);

        void RemoveAll();
    }
}