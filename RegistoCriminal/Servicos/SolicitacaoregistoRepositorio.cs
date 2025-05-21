using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public class SolicitacaoregistoRepositorio : IRepositorioDependente<Solicitacaoregisto, int>
    {

        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<Solicitacaoregisto> _contextSolicitacaoregisto;
        //private readonly DbSet<AspNetUser> _contextUsers;
        public SolicitacaoregistoRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextSolicitacaoregisto = _Context.Solicitacaoregistos ??
                throw new ArgumentNullException();
        }
        public Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException(); 
        }

        public Task<IEnumerable<Solicitacaoregisto>?> GetFkComParametersNormalAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            var solicitacao = _contextSolicitacaoregisto.AsNoTracking() as IQueryable<SolicitacaoregistoViewModel>;

            return await solicitacao.FirstOrDefaultAsync(s => s.Id == Id);
        }

        public Task<IEnumerable<Solicitacaoregisto>?> GetModelsByFkIdAsync(int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Solicitacaoregisto>?> GetTodosNormalAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            //var solicitacaoregistos = _contextSolicitacaoregisto.AsNoTracking() as IQueryable<Solicitacaoregisto>; 


            return await _contextSolicitacaoregisto.AsNoTracking().ToListAsync();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }


        public void Actualizar(Solicitacaoregisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextSolicitacaoregisto.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(Solicitacaoregisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextSolicitacaoregisto.Add(model);
        }

        public void Remover(Solicitacaoregisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextSolicitacaoregisto.Remove(model);
        }


        public async Task<bool> SaveAsync()
        {
            return (await _Context.SaveChangesAsync() >= 0);
        }
        public async Task BeginTrasactionAsync()
        {
            await _Context.Database.BeginTransactionAsync();
        }
        public async Task CommitTrasactionAsync()
        {
            await _Context.Database.CommitTransactionAsync();
        }
        public async Task RollbackTrasactionAsync()
        {
            await _Context.Database.RollbackTransactionAsync();
        }

    }
}
