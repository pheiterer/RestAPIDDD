using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Mappers;
using RestAPIDDD.Domain.Entities;

namespace RESTAPPDDD.Test.Application.Mapper
{
    public class MapperProdutoTests
    {
        private readonly MapperProduto _mapperProduto;

        public MapperProdutoTests()
        {
            _mapperProduto = new MapperProduto();
        }

        [Fact]
        public void MapperDtoToEntity_ShouldMapCorrectly()
        {
            // Arrange
            var produtoDto = new ProdutoDto
            {
                Id = 1,
                Nome = "Produto 1",
                Valor = 10.0m
            };

            // Act
            var result = _mapperProduto.MapperDtoToEntity(produtoDto);

            // Assert
            Assert.Equal(produtoDto.Id, result.Id);
            Assert.Equal(produtoDto.Nome, result.Nome);
            Assert.Equal(produtoDto.Valor, result.Valor);
        }

        [Fact]
        public void MapperEntityToDto_ShouldMapCorrectly()
        {
            // Arrange
            var produto = new Produto
            {
                Id = 1,
                Nome = "Produto 1",
                Valor = 10.0m,
                IsDisponivel = true
            };

            // Act
            var result = _mapperProduto.MapperEntityToDto(produto);

            // Assert
            Assert.Equal(produto.Id, result.Id);
            Assert.Equal(produto.Nome, result.Nome);
            Assert.Equal(produto.Valor, result.Valor);
        }

        [Fact]
        public void MapperListProdutosDto_ShouldMapCorrectly()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Valor = 10.0m, IsDisponivel = true },
                new Produto { Id = 2, Nome = "Produto 2", Valor = 20.0m, IsDisponivel = false }
            };

            // Act
            var result = _mapperProduto.MapperListProdutosDto(produtos);

            // Assert
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(produtos[0].Id, item.Id);
                    Assert.Equal(produtos[0].Nome, item.Nome);
                    Assert.Equal(produtos[0].Valor, item.Valor);
                },
                item =>
                {
                    Assert.Equal(produtos[1].Id, item.Id);
                    Assert.Equal(produtos[1].Nome, item.Nome);
                    Assert.Equal(produtos[1].Valor, item.Valor);
                });
        }
    }
}
