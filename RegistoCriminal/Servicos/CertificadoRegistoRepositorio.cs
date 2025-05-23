using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public class CertificadoRegistoRepositorio : IRepositorioDependente<CertificadoRegisto, int>
    {
        private readonly RegistoCriminalContext _Context;
        private readonly DbSet<CertificadoRegisto> _contextCertificadoRegisto;
        private readonly UserManager<ApplicationUser> _userManager;
        public CertificadoRegistoRepositorio(RegistoCriminalContext context, UserManager<ApplicationUser> userManager)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextCertificadoRegisto = _Context.CertificadoRegistos ??
                throw new ArgumentNullException();
            _userManager = userManager;
        }
        public async Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, int fkId)
        {
            var certificados = (from c in _contextCertificadoRegisto
                                join f in _Context.FuncionarioJudicials on c.IdFuncionarioEmissor equals f.Id
                                join u in _userManager.Users on f.IdUtilizador equals u.Id
                                where f.Id == fkId
                                select new CertidicadoRegistoViewModel()
                                {
                                    Id = c.Id,
                                    DataEmissao = c.DataEmissao,
                                    DataValidade = c.DataValidade,
                                    NumeroReferencia = c.NumeroReferencia,
                                    Conteudo = c.Conteudo,
                                    EstadoCertificado = c.EstadoCertificado,
                                    FuncionarioEmissor = u.NomeCompleto
                                });

            return await certificados.Cast<IViewModel>().AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<CertificadoRegisto>?> GetFkComParametersNormalAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public async Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            var certificados = (from c in _contextCertificadoRegisto
                            join f in _Context.FuncionarioJudicials on c.IdFuncionarioEmissor equals f.Id
                            join u in _userManager.Users on f.IdUtilizador equals u.Id
                            where c.Id == Id
                            select new CertidicadoRegistoViewModel()
                            {
                                Id = c.Id,
                                DataEmissao = c.DataEmissao,
                                DataValidade = c.DataValidade,
                                NumeroReferencia = c.NumeroReferencia,
                                Conteudo = c.Conteudo,
                                EstadoCertificado = c.EstadoCertificado,
                                FuncionarioEmissor = u.NomeCompleto
                            });

            return await certificados.AsNoTracking().FirstOrDefaultAsync();

        }

        public Task<IEnumerable<CertificadoRegisto>?> GetModelsByFkIdAsync(int fkId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            var certificados = (from c in _contextCertificadoRegisto
                                join f in _Context.FuncionarioJudicials on c.IdFuncionarioEmissor equals f.Id
                                join u in _userManager.Users on f.IdUtilizador equals u.Id
                                select new CertidicadoRegistoViewModel()
                                {
                                    Id = c.Id,
                                    DataEmissao = c.DataEmissao,
                                    DataValidade = c.DataValidade,
                                    NumeroReferencia = c.NumeroReferencia,
                                    Conteudo = c.Conteudo,
                                    EstadoCertificado = c.EstadoCertificado,
                                    FuncionarioEmissor = u.NomeCompleto
                                });

            return await certificados.Cast<IViewModel>().AsNoTracking().ToListAsync();
        }
        

        public async Task<IEnumerable<CertificadoRegisto>?> GetTodosNormalAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            return await _contextCertificadoRegisto.AsNoTracking().ToListAsync();
        }

        public Task<bool> ModelExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }


        public void Actualizar(CertificadoRegisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _Context.Entry(model).State = EntityState.Modified;
        }

        public void Adicionar(CertificadoRegisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCertificadoRegisto.Add(model);
        }

        public void Remover(CertificadoRegisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCertificadoRegisto.Remove(model);
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
