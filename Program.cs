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
            var sistema = new SistemaReservas();

            var cliente = sistema.RegistrarCliente("Ana", 25, "ana@mail.com");
            sistema.CrearReserva(cliente, "AV123");

            // Mostrar logs registrados (a través de ILogger)
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
