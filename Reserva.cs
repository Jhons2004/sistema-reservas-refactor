namespace refactor
{
    /// <summary>
    /// Entidad de dominio para una reserva.
    /// Refactor: se introduce para modelar explícitamente la transacción de reserva.
    /// </summary>
    public class Reserva
    {
        public Cliente Cliente { get; set; }
        public string CodigoVuelo { get; set; }
    }
}
