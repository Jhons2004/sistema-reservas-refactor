using System;
using refactor.Abstracciones;

namespace refactor.Aplicacion
{
    /// <summary>
    /// Servicio de aplicación enfocado en operaciones de cliente (alta cohesión).
    /// Refactor: extrae la lógica de registro desde la fachada, aplicando SRP y DIP.
    /// </summary>
    public class ClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly ILogger _logger;

        public ClienteService(IClienteRepository repo, ILogger logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Cliente RegistrarCliente(string nombre, int edad, string email)
        {
            var cliente = new Cliente { Nombre = nombre, Edad = edad, Email = email };
            _repo.Add(cliente);
            _logger.Info($"Cliente registrado: {cliente.Nombre}");
            return cliente;
        }
    }
}
