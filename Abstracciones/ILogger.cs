namespace refactor.Abstracciones
{
    /// <summary>
    /// Abstracción de logging; permite cambiar implementación sin afectar el dominio.
    /// </summary>
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}
