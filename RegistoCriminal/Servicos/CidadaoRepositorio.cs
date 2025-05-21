using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegistoCriminal.Servicos
{
    public class CidadaoRepositorio : IRepositorioDependente<Cidadao, string>
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<Cidadao> _contextCidadao;
        //private readonly DbSet<AspNetUser> _contextUsers;
        public CidadaoRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextCidadao = _Context.Cidadaos ??
                throw new ArgumentNullException();
            //_contextUsers = _context.AspNetUsers ??
            //    throw new ArgumentNullException();
        }

        public async Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, string fkId)
        {

            if (parametros == null) throw new ArgumentNullException();

            var cidadaos = (from c in _contextCidadao
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            where c.IdUtilizador == fkId
                            select new CidadoViewModel()
                            {
                                Id = c.Id,
                                NomeCompleto = u.NomeCompleto,
                                NumBi = c.NumBi,
                                Endereco = c.Endereco,
                                Provincia = c.Provincia,
                                Distrito = c.Distrito,
                                Datanascimento = c.Datanascimento,
                                IdUtilizador = c.IdUtilizador,
                            });

            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                cidadaos = cidadaos.Where(
                    c => c.NomeCompleto.Contains(searchQuery) 
                    || c.NumBi.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    cidadaos = cidadaos.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    cidadaos = cidadaos.OrderBy(e => e.Id);
            //}

            return await cidadaos.Cast<IViewModel>().ToListAsync();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException();

            var cidadaos = (from c in _contextCidadao
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            where c.Id == Id 
                            select new CidadoViewModel()
                            {
                                Id = c.Id,
                                NomeCompleto = u.NomeCompleto,
                                NumBi = c.NumBi,
                                Endereco = c.Endereco,
                                Provincia = c.Provincia,
                                Distrito = c.Distrito,
                                Datanascimento = c.Datanascimento,
                                IdUtilizador = c.IdUtilizador,
                            }).AsNoTracking();

            return await cidadaos.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            var cidadaos = (from c in _contextCidadao
                            join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                            select new CidadoViewModel()
                            {
                                Id = c.Id,
                                NomeCompleto = u.NomeCompleto,
                                NumBi = c.NumBi,
                                Endereco = c.Endereco,
                                Provincia = c.Provincia,
                                Distrito = c.Distrito,
                                Datanascimento = c.Datanascimento,
                                IdUtilizador = c.IdUtilizador,
                            });

            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                cidadaos = cidadaos.Where(
                    c => c.NomeCompleto.Contains(searchQuery)
                    || c.NumBi.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    cidadaos = cidadaos.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    cidadaos = cidadaos.OrderBy(e => e.Id);
            //}

            return await cidadaos.Cast<IViewModel>().ToListAsync();
        }

        public Task<IEnumerable<Cidadao>?> GetModelsByFkIdAsync(string fkId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cidadao>?> GetTodosNormalAsync(ParametrosPages parametros)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cidadao>?> GetFkComParametersNormalAsync(ParametrosPages parametros, string fkId)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Cidadao model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            //_contextCidadao.Update(model);
            _Context.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(Cidadao model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCidadao.Add(model);

        }

        public void Remover(Cidadao model, string fkId)
        {
            if (fkId == null) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCidadao.Remove(model);
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
