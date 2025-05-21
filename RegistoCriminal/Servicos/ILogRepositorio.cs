using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;

namespace RegistoCriminal.Servicos
{
    public interface ILogRepositorio
    {
        Task<IEnumerable<Log>> GetTodosAsync();
        Task AdicionarLog(string userId, string? action, string? details, string? ip);
    }
}
