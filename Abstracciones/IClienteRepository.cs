using System.Collections.Generic;

namespace refactor.Abstracciones
{
    /// <summary>
    /// Puerto de acceso a persistencia de clientes (Arquitectura Hexagonal / Puertos y Adaptadores).
    /// </summary>
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        IEnumerable<Cliente> GetAll();
    }
}
