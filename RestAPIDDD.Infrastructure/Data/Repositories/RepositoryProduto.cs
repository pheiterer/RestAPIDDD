using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public class RepositoryProduto(SqlContext context) : RepositoryBase<Produto>(context), IRepositoryProduto
    {
    }
}
