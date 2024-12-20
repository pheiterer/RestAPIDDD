using RestAPIDDD.Application.Dtos;

namespace RestAPIDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDto entity);
        void Update(ProdutoDto entity);
        void Remove(ProdutoDto entity);
        Task<IEnumerable<ProdutoDto>> GetAll();
        Task<ProdutoDto> GetById(uint id);
    }
}
