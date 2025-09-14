using System.Collections.Generic;
using refactor.Abstracciones;

namespace refactor.Infraestructura
{
    /// <summary>
    /// Implementación simple en memoria para persistencia de clientes.
    /// </summary>
    public class ClienteMemoryRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void Add(Cliente cliente) => _clientes.Add(cliente);

        public IEnumerable<Cliente> GetAll() => _clientes;
    }
}
