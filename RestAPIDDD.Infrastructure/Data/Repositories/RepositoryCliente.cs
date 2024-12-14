using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(SqlContext context) : base(context)
        {
        }
    }
}
