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
        //private readonly DbSet<AspNetUser> _contextUsers;
        public CertificadoRegistoRepositorio(RegistoCriminalContext context)
        {
            _Context = context ??
                throw new ArgumentNullException();
            _contextCertificadoRegisto = _Context.CertificadoRegistos ??
                throw new ArgumentNullException();
        }
        public Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CertificadoRegisto>?> GetFkComParametersNormalAsync(ParametrosPages parametros, int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IViewModel?> GetModelByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CertificadoRegisto>?> GetModelsByFkIdAsync(int fkId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros)
        {
            throw new NotImplementedException();
        }
        

        public async Task<IEnumerable<CertificadoRegisto>?> GetTodosNormalAsync(ParametrosPages parametros)
        {
            if (parametros == null) throw new ArgumentNullException();

            //var CertificadoRegistos = _contextCertificadoRegisto.AsNoTracking() as IQueryable<CertificadoRegisto>; 


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

            _contextCertificadoRegisto.Add(model);
        }

        public void Adicionar(CertificadoRegisto model, int fkId)
        {
            if (fkId <= 0) throw new ArgumentOutOfRangeException();
            if (model == null) throw new ArgumentNullException();

            _contextCertificadoRegisto.Update(model);
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
