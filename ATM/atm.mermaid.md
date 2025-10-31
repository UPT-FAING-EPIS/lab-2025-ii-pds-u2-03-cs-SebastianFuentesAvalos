# Diagrama de Clases - Sistema ATM (Patrón Command)

```mermaid
classDiagram
    class ICommand {
        <<interface>>
        +Execute() void
    }
    
    class DepositCommand {
        -account: Account
        -amount: decimal
        +DepositCommand(account: Account, amount: decimal)
        +Execute() void
    }
    
    class WithdrawCommand {
        -account: Account
        -amount: decimal
        +WithdrawCommand(account: Account, amount: decimal)
        +Execute() void
    }
    
    class Account {
        +AccountNumber: int
        +AccountBalance: decimal
        +Withdraw(amount: decimal) void
        +Deposit(amount: decimal) void
    }
    
    class ATM {
        -commands: List~ICommand~
        +Action(command: ICommand) void
        +ExecuteCommands() void
    }
    
    ICommand <|.. DepositCommand : implements
    ICommand <|.. WithdrawCommand : implements
    DepositCommand --> Account : operates on
    WithdrawCommand --> Account : operates on
    ATM --> ICommand : executes
```

## Descripción del Patrón Command

El patrón Command encapsula una solicitud como un objeto, permitiendo parametrizar clientes con diferentes solicitudes, colas o solicitudes de registro.

### Componentes:
- **ICommand**: Interfaz común para todos los comandos
- **Comandos Concretos**: DepositCommand, WithdrawCommand
- **Account**: Receptor que sabe cómo realizar las operaciones
- **ATM**: Invocador que ejecuta los comandos