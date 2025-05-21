using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public class PagamentoRepositorio : IRepositorioDependente<Pagamento, int>
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<Pagamento> _contextPagamento;
        //private readonly DbSet<AspNetUser> _contextUsers;
        public PagamentoRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextPagamento = _Context.Pagamentos ??
                throw new ArgumentNullException();
        }
        public Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pagamento>?> GetFkComParametersNormalAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            var RegistosCriminals = (from p in _contextPagamento
                                     where p.Id == Id
                                     select new PagamentoViewModel()
                                     {
                                          Id = p.Id,
                                          Valor = p.Valor,
                                          Metodo = p.Metodo,
                                          Referencia = p.Referencia,
                                          IdSolicitacao = p.IdSolicitacao,
                                     }).AsNoTracking(); 

            return await RegistosCriminals.FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Pagamento>?> GetModelsByFkIdAsync(int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<Pagamento>?> GetTodosNormalAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();


            return await _contextPagamento.AsNoTracking().ToListAsync();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }


        public void Actualizar(Pagamento model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextPagamento.Add(model);
            _contextPagamento.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(Pagamento model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextPagamento.Add(model);
        }

        public void Remover(Pagamento model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextPagamento.Remove(model);
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
