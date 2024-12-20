using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository) => _repository = repository;

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<TEntity> GetById(uint id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
