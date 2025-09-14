# Refactorización: Alta Cohesión, Bajo Acoplamiento, SOLID

## Objetivos
- Aumentar cohesión separando responsabilidades en servicios.
- Reducir acoplamiento introduciendo abstracciones (interfaces) y dependencias inyectables.
- Aplicar principios SOLID y patrones de diseño (Fachada, Puertos y Adaptadores).

## Estructura
- Abstracciones: puertos (`IClienteRepository`, `IEmailService`, `ILogger`).
- Aplicacion: casos de uso (`ClienteService`, `ReservaService`).
- Infraestructura: adaptadores concretos (`ClienteMemoryRepository`, `ConsoleEmailService`, `MemoryLogger`).
- Dominio: entidades (`Cliente`, `Reserva`).
- Fachada: `SistemaReservas` orquesta servicios.

## Diagrama UML (PlantUML)

```plantuml
@startuml
skinparam packageStyle rectangle

package Dominio {
  class Cliente {
    - Nombre: string
    - Email: string
    - Edad: int
  }
  class Reserva {
    - Cliente: Cliente
    - CodigoVuelo: string
  }
}

package Abstracciones {
  interface IClienteRepository {
    + Add(Cliente)
    + GetAll(): IEnumerable<Cliente>
  }
  interface IEmailService {
    + Send(destino, asunto, cuerpo)
  }
  interface ILogger {
    + Info(msg)
    + Warn(msg)
    + Error(msg)
  }
}

package Aplicacion {
  class ClienteService {
    - _repo: IClienteRepository
    - _logger: ILogger
    + RegistrarCliente(nombre, edad, email): Cliente
  }
  class ReservaService {
    - _emailService: IEmailService
    - _logger: ILogger
    + CrearReserva(cliente, vuelo): Reserva
  }
}

package Infraestructura {
  class ClienteMemoryRepository
  class ConsoleEmailService
  class MemoryLogger
}

class SistemaReservas {
  - _clienteService: ClienteService
  - _reservaService: ReservaService
  - _repo: IClienteRepository
  - _logger: ILogger
  + RegistrarCliente(...): Cliente
  + CrearReserva(...): Reserva
  + ListarClientes(): IReadOnlyCollection<Cliente>
  + GetLogger(): ILogger
}

IClienteRepository <|.. ClienteMemoryRepository
IEmailService <|.. ConsoleEmailService
ILogger <|.. MemoryLogger

SistemaReservas --> ClienteService
SistemaReservas --> ReservaService
SistemaReservas --> IClienteRepository
SistemaReservas --> ILogger

ClienteService --> IClienteRepository
ClienteService --> ILogger
ReservaService --> IEmailService
ReservaService --> ILogger
Reserva --> Cliente
@enduml
```

## Justificación
- SRP (Single Responsibility):
  - `ClienteService` sólo gestiona operaciones de cliente; `ReservaService` sólo gestiona reservas y notificaciones.
- OCP (Open/Closed):
  - Nuevas implementaciones de `ILogger` o `IEmailService` se añaden sin modificar servicios.
- LSP: Las implementaciones de interfaces pueden reemplazarse sin romper comportamiento.
- ISP: Interfaces pequeñas y específicas (`ILogger`, `IEmailService`, `IClienteRepository`).
- DIP: Servicios dependen de abstracciones, no de concreciones.

Patrones
- Fachada: `SistemaReservas` expone una API simple, orquestando servicios.
- Puertos y Adaptadores (Hexagonal): Abstracciones en `Abstracciones` y adaptadores en `Infraestructura`.

## Cómo compilar y ejecutar
```powershell
Set-Location "C:\Analisis De sistemas refactorizacion"
dotnet msbuild ".\codigo refactor\refactor\refactor.csproj" /t:Build /p:Configuration=Debug
& ".\codigo refactor\refactor\bin\Debug\refactor.exe"
```

## Repositorio publicado
- Enlace: https://github.com/Jhons2004/sistema-reservas-refactor
