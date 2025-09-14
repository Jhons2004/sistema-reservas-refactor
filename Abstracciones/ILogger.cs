namespace refactor.Abstracciones
{
    /// <summary>
    /// Abstracción de logging; permite cambiar implementación sin afectar el dominio.
    /// Refactor: reemplaza el uso de estado global 'Globals.logs' para evitar acoplamiento común
    /// y facilitar pruebas (DIP, OCP).
    /// </summary>
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
}
