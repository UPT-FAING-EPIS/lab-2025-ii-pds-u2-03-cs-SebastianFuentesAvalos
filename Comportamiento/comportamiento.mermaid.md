# Diagrama de Clases - Sistema de Comportamiento (Patrón Observer)

```mermaid
classDiagram
    class IObserver {
        <<interface>>
        +Update(message: string) void
    }
    
    class ISubject {
        <<interface>>
        +Attach(observer: IObserver) void
        +Detach(observer: IObserver) void
        +Notify() void
    }
    
    class ConcreteSubject {
        -observers: List~IObserver~
        -state: string
        +Attach(observer: IObserver) void
        +Detach(observer: IObserver) void
        +Notify() void
        +SetState(state: string) void
        +GetState() string
    }
    
    class ConcreteObserver {
        -subject: ISubject
        +LastMessage: string
        +ConcreteObserver(subject: ISubject)
        +Update(message: string) void
    }
    
    IObserver <|.. ConcreteObserver : implements
    ISubject <|.. ConcreteSubject : implements
    ConcreteSubject --> IObserver : notifies
    ConcreteObserver --> ISubject : observes
```

## Descripción del Patrón Observer

El patrón Observer define una dependencia uno-a-muchos entre objetos, de manera que cuando un objeto cambia su estado, todos los dependientes son notificados y actualizados automáticamente.

### Componentes:
- **IObserver**: Interfaz para objetos que deben ser notificados de cambios
- **ISubject**: Interfaz para el objeto observable
- **ConcreteSubject**: Implementación concreta del sujeto observable
- **ConcreteObserver**: Implementación concreta del observador