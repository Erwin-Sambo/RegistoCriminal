using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public class RegistosCriminalRepositorio : IRepositorioDependente<RegistosCriminal, int>
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<RegistosCriminal> _contextRegistosCriminal;
        //private readonly DbSet<AspNetUser> _contextUsers;
        public RegistosCriminalRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextRegistosCriminal = _Context.RegistosCriminals ??
                throw new ArgumentNullException();
            //_contextUsers = _context.AspNetUsers ??
            //    throw new ArgumentNullException();
        }

        public async Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, int fkId)
        {

            if (parametros == null) throw new ArgumentNullException();

            var RegistosCriminals = (from r in _contextRegistosCriminal
                                     join c in _Context.Cidadaos on r.Id equals c.Id
                                     //join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                                     where c.Id == fkId
                                     select new RegistoCriminaViewModel()
                                     {
                                         Id = r.Id,
                                         //NomeCompleto = u.NomeCompleto,
                                         NumeroProcesso = r.NumeroProcesso,
                                         DataOcorrencia = r.DataOcorrencia,
                                         TipoOcorrencia = r.TipoOcorrencia,
                                         Sentenca = r.Sentenca,
                                         DataSentenca = r.DataSentenca,
                                         Cumprido = r.Cumprido,
                                         Observacoes = r.Observacoes,
                                         IdCidado = c.Id,
                                     }).AsNoTracking();


            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                RegistosCriminals = RegistosCriminals.Where(
                    c => c.NomeCompleto.Contains(searchQuery)
                    || c.NumeroProcesso.Contains(searchQuery)
                    || c.TipoOcorrencia.Contains(searchQuery)
                    || c.Sentenca.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    RegistosCriminals = RegistosCriminals.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    RegistosCriminals = RegistosCriminals.OrderBy(e => e.Id);
            //}

            return await RegistosCriminals.Cast<IViewModel>().ToListAsync();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException();

            var RegistosCriminals = (from r in _contextRegistosCriminal
                                        join c in _Context.Cidadaos on r.Id equals c.Id
                                        //join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                                        where r.Id == Id
                                        select new RegistoCriminaViewModel()
                                        {
                                            Id = r.Id,
                                            //NomeCompleto = u.NomeCompleto,
                                            NumeroProcesso = r.NumeroProcesso,
                                            DataOcorrencia = r.DataOcorrencia,
                                            TipoOcorrencia = r.TipoOcorrencia,
                                            Sentenca = r.Sentenca,
                                            DataSentenca = r.DataSentenca,
                                            Cumprido = r.Cumprido,
                                            Observacoes = r.Observacoes,
                                            IdCidado = c.Id,
                                        }).AsNoTracking();

            return await RegistosCriminals.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            var RegistosCriminals = (from r in _contextRegistosCriminal
                                     join c in _Context.Cidadaos on r.Id equals c.Id
                                     //join u in _Context.AspNetUsers on c.IdUtilizador equals u.Id
                                     select new RegistoCriminaViewModel()
                                        {
                                            Id = r.Id,
                                            //NomeCompleto = u.NomeCompleto,
                                            NumeroProcesso = r.NumeroProcesso,
                                            DataOcorrencia = r.DataOcorrencia,
                                            TipoOcorrencia = r.TipoOcorrencia,
                                            Sentenca = r.Sentenca,
                                            DataSentenca = r.DataSentenca,
                                            Cumprido = r.Cumprido,
                                            Observacoes = r.Observacoes,
                                            IdCidado = c.Id,
                                        });

            if (!string.IsNullOrEmpty(parametros.pesquisaQuery))
            {
                var searchQuery = parametros.pesquisaQuery.Trim();
                RegistosCriminals = RegistosCriminals.Where(
                    c => c.NomeCompleto.Contains(searchQuery)
                    || c.NumeroProcesso.Contains(searchQuery)
                    || c.TipoOcorrencia.Contains(searchQuery)
                    || c.Sentenca.Contains(searchQuery)
                    );
            }


            //if (!string.IsNullOrEmpty(parametros.OrderBy))
            //{
            //    RegistosCriminals = RegistosCriminals.OrderBy(parametros.OrderBy);
            //}
            //else
            //{
            //    RegistosCriminals = RegistosCriminals.OrderBy(e => e.Id);
            //}

            return await RegistosCriminals.Cast<IViewModel>().ToListAsync();
        }

        public Task<IEnumerable<RegistosCriminal?>> GetModelsByFkIdAsync(int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegistosCriminal>?> GetTodosNormalAsync(ParametrosPages parametros)
        {

            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegistosCriminal>?> GetFkComParametersNormalAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(RegistosCriminal model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextRegistosCriminal.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(RegistosCriminal model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextRegistosCriminal.Add(model);
        }

        public void Remover(RegistosCriminal model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextRegistosCriminal.Remove(model);
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
