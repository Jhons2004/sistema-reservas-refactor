namespace refactor.Abstracciones
{
    /// <summary>
    /// Servicio para envío de correos electrónicos.
    /// Refactor: extraído desde la lógica de dominio para reducir acoplamiento con infraestructura
    /// (SRP, DIP) y poder sustituir la implementación (OCP).
    /// </summary>
    public interface IEmailService
    {
        void Send(string destino, string asunto, string cuerpo);
    }
}
