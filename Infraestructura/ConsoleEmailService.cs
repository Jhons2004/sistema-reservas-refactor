using System;
using refactor.Abstracciones;

namespace refactor.Infraestructura
{
    /// <summary>
    /// Implementación de IEmailService que utiliza la consola como salida.
    /// </summary>
    public class ConsoleEmailService : IEmailService
    {
        public void Send(string destino, string asunto, string cuerpo)
        {
            Console.WriteLine($"Enviando correo a {destino}: {asunto} - {cuerpo}");
        }
    }
}
