namespace refactor.Abstracciones
{
    /// <summary>
    /// Servicio para envío de correos electrónicos.
    /// Extraído para reducir acoplamiento con infraestructura.
    /// </summary>
    public interface IEmailService
    {
        void Send(string destino, string asunto, string cuerpo);
    }
}
