using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Application.Interfaces.Mapper
{
    public interface IMapperProduto
    {
        Produto MapperDtoToEntity(ProdutoDto produtoDto);
        IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos);
        ProdutoDto MapperEntityToDto(Produto produto);
    }
}
