namespace refactor
{
    /// <summary>
    /// Entidad de dominio para una reserva.
    /// </summary>
    public class Reserva
    {
        public Cliente Cliente { get; set; }
        public string CodigoVuelo { get; set; }
    }
}
