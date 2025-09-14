using System;
using refactor.Abstracciones;

namespace refactor.Aplicacion
{
    /// <summary>
    /// Servicio de aplicación para gestión de reservas.
    /// Aplica SRP, desacoplando reglas y envío de correo.
    /// </summary>
    public class ReservaService
    {
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public ReservaService(IEmailService emailService, ILogger logger)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Reserva CrearReserva(Cliente cliente, string vuelo)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (string.IsNullOrWhiteSpace(vuelo)) throw new ArgumentException("Código de vuelo inválido", nameof(vuelo));

            if (cliente.Edad < 18)
            {
                _logger.Warn($"Cliente menor de edad: {cliente.Nombre}");
                throw new InvalidOperationException("El cliente no puede reservar por ser menor de edad.");
            }

            var reserva = new Reserva { Cliente = cliente, CodigoVuelo = vuelo };
            _logger.Info($"Reserva creada para {cliente.Nombre} en vuelo {vuelo}");
            _emailService.Send(cliente.Email, "Reserva confirmada", $"Reserva confirmada en vuelo {vuelo}");
            return reserva;
        }
    }
}
