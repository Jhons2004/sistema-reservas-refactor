using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    /// <summary>
    /// Entidad de dominio que representa a un cliente.
    /// Refactor: antes existían campos públicos; ahora encapsulamos usando propiedades
    /// automáticas para permitir validaciones futuras y evitar acoplamiento de contenido.
    /// </summary>
    public class Cliente
    {
        // Refactor: reemplazo de campos públicos por propiedades (SRP, encapsulación).
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Email}), {Edad} años";
        }
    }
}
