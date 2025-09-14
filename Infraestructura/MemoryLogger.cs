using System.Collections.Generic;
using refactor.Abstracciones;

namespace refactor.Infraestructura
{
    /// <summary>
    /// Logger en memoria; conserva compatibilidad con inspección de logs durante ejecución.
    /// </summary>
    public class MemoryLogger : ILogger
    {
        public List<string> Entries { get; } = new List<string>();

        public void Info(string message) => Entries.Add($"INFO: {message}");
        public void Warn(string message) => Entries.Add($"WARN: {message}");
        public void Error(string message) => Entries.Add($"ERROR: {message}");
    }
}
