using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCliente(SqlContext context) : RepositoryBase<Cliente>(context), IRepositoryCliente
    {
    }
}
