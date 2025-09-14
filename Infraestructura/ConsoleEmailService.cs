using System;
using refactor.Abstracciones;

namespace refactor.Infraestructura
{
    /// <summary>
    /// Implementación de IEmailService que utiliza la consola como salida.
    /// Refactor: actúa como adaptador de demostración; en producción se sustituye por SMTP/API.
    /// </summary>
    public class ConsoleEmailService : IEmailService
    {
        public void Send(string destino, string asunto, string cuerpo)
        {
            Console.WriteLine($"Enviando correo a {destino}: {asunto} - {cuerpo}");
        }
    }
}
