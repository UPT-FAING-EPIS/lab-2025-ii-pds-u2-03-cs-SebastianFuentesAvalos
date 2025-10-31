using NUnit.Framework;
using Comportamiento.Domain;

namespace Comportamiento.Domain.Tests
{
    public class ObserverTests
    {
        [Test]
        public void Observer_Receives_Notification()
        {
            var subject = new ConcreteSubject();
            var observer = new ConcreteObserver();
            subject.Attach(observer);
            subject.Notify("Mensaje de prueba");
            Assert.That(observer.LastMessage, Is.EqualTo("Mensaje de prueba"));
        }

        [Test]
        public void Observer_Detach_DoesNotReceiveNotification()
        {
            var subject = new ConcreteSubject();
            var observer = new ConcreteObserver();
            subject.Attach(observer);
            subject.Detach(observer);
            subject.Notify("Otro mensaje");
            Assert.That(observer.LastMessage, Is.EqualTo(string.Empty));
        }
    }
}
