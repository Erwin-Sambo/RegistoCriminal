using RegistoCriminal.Entities;
using RegistoCriminal.Parametros;
using RegistoCriminal.ViewModels;

namespace RegistoCriminal.Servicos
{
    public interface IRepositorioDependente<T, S> : IBackRollDatabase
    {
        void Adicionar(T model, S fkId);
        void Actualizar(T model, S fkId);
        void Remover(T model, S fkId);
        Task<IEnumerable<T>?> GetTodosNormalAsync(ParametrosPages parametros);
        Task<IEnumerable<T>?> GetFkComParametersNormalAsync(ParametrosPages parametros, S fkId);
        Task<IEnumerable<IViewModel>?> GetTodosAsync(ParametrosPages parametros);
        Task<IEnumerable<IViewModel>?> GetFkComParametersAsync(ParametrosPages parametros, S fkId);
        Task<IEnumerable<T>?> GetModelsByFkIdAsync(S fkId);
        Task<IViewModel?> GetModelByIdAsync(int Id);
        Task<bool> ModelExistsAsync(int Id);

    }
}
