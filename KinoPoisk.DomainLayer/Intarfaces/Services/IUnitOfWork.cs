namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUnitOfWork {
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        public Task CommitAsync();
    }
}

