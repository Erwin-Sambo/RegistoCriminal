using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;

namespace RegistoCriminal.Servicos
{
    public class LogRepositorio : ILogRepositorio
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<Log> _contextCidadao;
        public LogRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextCidadao = _Context.Logs ??
                throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Log>> GetTodosAsync()
        {
            return await _contextCidadao.AsNoTracking().ToListAsync();
        }

        public void LogUserAction(Log model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCidadao.Update(model);
        }


        public async Task AdicionarLog(string userId, string? action, string? details, string? ip)
        {
            var log = new Log
            {
                Iduser = userId,
                Acao = action,
                Detalhes = details,
                Ipaddress = ip
            };

            _Context.Logs.Add(log);

            await _Context.SaveChangesAsync();
        }
    }
}
