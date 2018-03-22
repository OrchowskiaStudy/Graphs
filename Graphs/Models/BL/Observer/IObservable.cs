namespace Graphs.Models.BL.Observer
{
    public interface IObservable
    {
        void NotifyObservers(IObserver except);

        void Add(IObserver observer);

        void Remove(IObserver observer);

        void RemoveAll();
    }
}