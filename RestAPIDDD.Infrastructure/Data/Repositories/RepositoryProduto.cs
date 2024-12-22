using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public sealed class RepositoryProduto(SqlContext context) : RepositoryBase<Produto>(context), IRepositoryProduto
    {
    }
}
