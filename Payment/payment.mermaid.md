# Diagrama de Clases - Sistema de Pago (Patrón Strategy)

```mermaid
classDiagram
    class IPaymentStrategy {
        <<interface>>
        +Pay(amount: decimal) bool
    }
    
    class CashPaymentStrategy {
        +Pay(amount: decimal) bool
    }
    
    class CreditCardPaymentStrategy {
        -cardNumber: string
        -expiryDate: string
        +Pay(amount: decimal) bool
    }
    
    class DebitCardPaymentStrategy {
        -cardNumber: string
        -pin: string
        +Pay(amount: decimal) bool
    }
    
    class PaymentContext {
        -strategy: IPaymentStrategy
        +SetPaymentStrategy(strategy: IPaymentStrategy) void
        +Pay(amount: decimal) bool
    }
    
    class PaymentService {
        -context: PaymentContext
        +ProcessPayment(amount: decimal, strategy: IPaymentStrategy) bool
    }
    
    IPaymentStrategy <|.. CashPaymentStrategy : implements
    IPaymentStrategy <|.. CreditCardPaymentStrategy : implements
    IPaymentStrategy <|.. DebitCardPaymentStrategy : implements
    PaymentContext --> IPaymentStrategy : uses
    PaymentService --> PaymentContext : uses
```

## Descripción del Patrón Strategy

El patrón Strategy permite seleccionar algoritmos sobre la marcha. En este caso, diferentes estrategias de pago (efectivo, tarjeta de crédito, débito) pueden ser intercambiadas dinámicamente.

### Componentes:
- **IPaymentStrategy**: Interfaz común para todas las estrategias
- **Estrategias Concretas**: CashPaymentStrategy, CreditCardPaymentStrategy, DebitCardPaymentStrategy
- **PaymentContext**: Mantiene una referencia a la estrategia y delega el trabajo
- **PaymentService**: Cliente que usa el contexto