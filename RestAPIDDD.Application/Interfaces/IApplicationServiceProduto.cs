using RestAPIDDD.Application.Dtos;

namespace RestAPIDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        Task Add(ProdutoDto entity);
        Task Update(ProdutoDto entity);
        Task Remove(ProdutoDto entity);
        Task<IEnumerable<ProdutoDto>> GetAll();
        Task<ProdutoDto> GetById(uint id);
    }
}
