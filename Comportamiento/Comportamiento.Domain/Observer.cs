namespace Comportamiento.Domain
{
    // Interfaz Observer
    public interface IObserver
    {
        void Update(string message);
    }

    // Interfaz Subject
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }

    // Implementación concreta de Subject
    public class ConcreteSubject : ISubject
    {
        private readonly List<IObserver> _observers = new();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }

    // Implementación concreta de Observer
    public class ConcreteObserver : IObserver
    {
        public string LastMessage { get; private set; } = string.Empty;
        public void Update(string message)
        {
            LastMessage = message;
        }
    }
}
