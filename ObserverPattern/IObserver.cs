namespace ObserverPattern
{
    public interface IObserver
    {
        string Name { get; }
        void BeAttacked();
        void Help();
    }
}
