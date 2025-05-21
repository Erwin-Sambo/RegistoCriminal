using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public class FuncionarioJudicialRepositorio : IRepositorioDependente<FuncionarioJudicial, string>
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<FuncionarioJudicial> _contextFuncionarioJudicial;
        //private readonly DbSet<AspNetUser> _contextUsers;
        public FuncionarioJudicialRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextFuncionarioJudicial = _Context.FuncionarioJudicials ??
                throw new ArgumentNullException();
            //_contextUsers = _context.AspNetUsers ??
            //    throw new ArgumentNullException();
        }

        public async Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, string fkId)
        {

            if (parametros == null) throw new ArgumentNullException();

            var FuncionarioJudicials = (from c in _contextFuncionarioJudicial
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            where c.IdUtilizador == fkId
                            select new FuncionarioJudicialViewModel()
                            {
                                Id = c.Id,
                                Cargo = c.Cargo,
                                Departamento = c.Departamento,
                                Nivelacesso = c.Nivelacesso,
                                IdUtilizador = c.IdUtilizador
                            });

            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                FuncionarioJudicials = FuncionarioJudicials.Where(
                    c => c.NomeCompleto.Contains(searchQuery)
                    || c.Departamento.Contains(searchQuery)
                    || c.Cargo.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    FuncionarioJudicials = FuncionarioJudicials.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    FuncionarioJudicials = FuncionarioJudicials.OrderBy(e => e.Id);
            //}
            return await FuncionarioJudicials.Cast<IViewModel>().ToListAsync();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException();

            var FuncionarioJudicials = (from c in _contextFuncionarioJudicial
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            where c.Id == Id
                            select new FuncionarioJudicialViewModel()
                            {
                                Id = c.Id,
                                Cargo = c.Cargo,
                                Departamento = c.Departamento,
                                Nivelacesso = c.Nivelacesso,
                                IdUtilizador = c.IdUtilizador
                            }).AsNoTracking();

            return await FuncionarioJudicials.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            var FuncionarioJudicials = (from c in _contextFuncionarioJudicial
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            select new FuncionarioJudicialViewModel()
                            {
                                Id = c.Id,
                                Cargo = c.Cargo,
                                Departamento = c.Departamento,
                                Nivelacesso = c.Nivelacesso,
                                IdUtilizador = c.IdUtilizador,
                                NomeCompleto = u.NomeCompleto,
                            });

            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                FuncionarioJudicials = FuncionarioJudicials.Where(
                    c => c.NomeCompleto.Contains(searchQuery)
                    || c.Departamento.Contains(searchQuery)
                    || c.Cargo.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    FuncionarioJudicials = FuncionarioJudicials.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    FuncionarioJudicials = FuncionarioJudicials.OrderBy(e => e.Id);
            //}

            return await FuncionarioJudicials.Cast<IViewModel>().ToListAsync();
        }

        public Task<IEnumerable<FuncionarioJudicial?>> GetModelsByFkIdAsync(string fkId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncionarioJudicial?>> GetTodosNormalAsync(ParametrosPages parametros)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncionarioJudicial?>> GetFkComParametersNormalAsync(ParametrosPages parametros, string fkId)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(FuncionarioJudicial model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextFuncionarioJudicial.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(FuncionarioJudicial model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextFuncionarioJudicial.Add(model);
        }

        public void Remover(FuncionarioJudicial model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextFuncionarioJudicial.Remove(model);
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
