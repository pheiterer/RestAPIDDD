namespace RestAPIDDD.Doamin.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(uint id);
    }
}
