namespace RegistoCriminal.Servicos
{
    public interface IBackRollDatabase
    {
        public Task BeginTrasactionAsync();
        public Task CommitTrasactionAsync();
        public Task RollbackTrasactionAsync();
        Task<bool> SaveAsync();
    }
}
