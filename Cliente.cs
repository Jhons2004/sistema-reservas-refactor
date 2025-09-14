using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    /// <summary>
    /// Entidad de dominio que representa a un cliente.
    /// Se encapsulan los campos como propiedades para mejorar la cohesión y permitir validaciones.
    /// </summary>
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Email}), {Edad} años";
        }
    }
}
