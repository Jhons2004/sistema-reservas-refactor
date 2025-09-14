using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Refactor: el punto de entrada ahora usa la fachada que compone servicios internos
            // en lugar de contener lógica de negocio y de infraestructura.
            var sistema = new SistemaReservas();

            var cliente = sistema.RegistrarCliente("Ana", 25, "ana@mail.com");
            sistema.CrearReserva(cliente, "AV123");

            // Mostrar logs registrados (a través de ILogger) para observar la orquestación.
            var logger = sistema.GetLogger();
            if (logger is Infraestructura.MemoryLogger mem)
            {
                foreach (var entry in mem.Entries)
                {
                    System.Console.WriteLine(entry);
                }
            }
        }
    }
}
