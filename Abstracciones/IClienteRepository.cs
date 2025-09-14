using System.Collections.Generic;

namespace refactor.Abstracciones
{
    /// <summary>
    /// Puerto de acceso a persistencia de clientes (Arquitectura Hexagonal / Puertos y Adaptadores).
    /// Refactor: antes el almacenamiento estaba acoplado a una lista interna;
    /// ahora se externaliza vía interfaz para permitir múltiples implementaciones.
    /// </summary>
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        IEnumerable<Cliente> GetAll();
    }
}
