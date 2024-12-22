using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Application.Mappers
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDtoToEntity(ProdutoDto produtoDto)
        {
            return new Produto()
            {
                Id = produtoDto.Id ?? 0,
                Nome = produtoDto.Nome,
                Valor = produtoDto.Valor,
            };
        }

        public ProdutoDto MapperEntityToDto(Produto produto)
        {
            return new ProdutoDto()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor,
            };
        }

        public IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos)
        {
            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
            });
        }
    }
}
