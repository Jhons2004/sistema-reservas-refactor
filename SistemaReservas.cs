using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    using System;
    using System.Collections.Generic;
    using refactor.Abstracciones;
    using refactor.Aplicacion;
    using refactor.Infraestructura;

    /// <summary>
    /// Fachada del sistema que orquesta servicios de aplicación,
    /// manteniendo el nombre para compatibilidad con Program.Main.
    /// </summary>
    public class SistemaReservas
    {
        private readonly ClienteService _clienteService;
        private readonly ReservaService _reservaService;
        private readonly IClienteRepository _repo;
        private readonly ILogger _logger;

        public SistemaReservas()
        {
            // Composición por defecto (podría inyectarse desde Program para mayor flexibilidad)
            _logger = new MemoryLogger();
            _repo = new ClienteMemoryRepository();
            _clienteService = new ClienteService(_repo, _logger);
            _reservaService = new ReservaService(new ConsoleEmailService(), _logger);
        }

        public SistemaReservas(ClienteService clienteService, ReservaService reservaService, IClienteRepository repo, ILogger logger)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Cliente RegistrarCliente(string nombre, int edad, string email)
        {
            return _clienteService.RegistrarCliente(nombre, edad, email);
        }

        public Reserva CrearReserva(Cliente cliente, string vuelo)
        {
            var reserva = _reservaService.CrearReserva(cliente, vuelo);
            Console.WriteLine($"Reserva creada para {cliente.Nombre}");
            return reserva;
        }

        public IReadOnlyCollection<Cliente> ListarClientes()
        {
            // Exponer consulta de clientes registrados.
            return new List<Cliente>(_repo.GetAll()) as IReadOnlyCollection<Cliente>;
        }

        public ILogger GetLogger() => _logger;
    }
}
