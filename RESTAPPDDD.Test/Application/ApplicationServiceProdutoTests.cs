using Moq;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Application;
using RestAPIDDD.Doamin.Core.Interfaces.Services;
using RestAPIDDD.Domain.Entities;

namespace RESTAPPDDD.Test.Application
{
    public class ApplicationServiceProdutoTests
    {
        private readonly Mock<IServiceProduto> _mockServiceProduto;
        private readonly Mock<IMapperProduto> _mockMapperProduto;
        private readonly ApplicationServiceProduto _applicationServiceProduto;
        private readonly List<Produto> _produtos;
        private readonly List<ProdutoDto> _produtoDtos;

        public ApplicationServiceProdutoTests()
        {
            _mockServiceProduto = new Mock<IServiceProduto>();
            _mockMapperProduto = new Mock<IMapperProduto>();
            _applicationServiceProduto = new ApplicationServiceProduto(_mockServiceProduto.Object, _mockMapperProduto.Object);
            _produtos = new List<Produto>
                {
                    new Produto { Id = 1, Nome = "Produto 1", Valor = 10.0m, IsDisponivel = true },
                    new Produto { Id = 2, Nome = "Produto 2", Valor = 20.0m, IsDisponivel = false }
                };
            _produtoDtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Id = 1, Nome = "Produto 1", Valor = 10.0m },
                    new ProdutoDto { Id = 2, Nome = "Produto 2", Valor = 20.0m }
                };
        }

        [Fact]
        public async Task Add_ShouldCallServiceAdd()
        {
            // Arrange
            var produtoDto = new ProdutoDto { Id = 1, Nome = "Produto 1", Valor = 10.0m };
            var produto = new Produto { Id = 1, Nome = "Produto 1", Valor = 10.0m, IsDisponivel = true };
            _mockMapperProduto.Setup(m => m.MapperDtoToEntity(produtoDto)).Returns(produto);

            // Act
            await _applicationServiceProduto.Add(produtoDto);

            // Assert
            _mockServiceProduto.Verify(s => s.Add(produto), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProdutos()
        {
            // Arrange
            _mockServiceProduto.Setup(s => s.GetAll()).ReturnsAsync(_produtos);
            _mockMapperProduto.Setup(m => m.MapperListProdutosDto(_produtos)).Returns(_produtoDtos);

            // Act
            var result = await _applicationServiceProduto.GetAll();

            // Assert
            Assert.Equal(_produtoDtos, result);
        }

        [Fact]
        public async Task GetById_ShouldReturnProduto()
        {
            // Arrange
            var produto = _produtos.First();
            var produtoDto = _produtoDtos.First();
            _mockServiceProduto.Setup(s => s.GetById(1)).ReturnsAsync(produto);
            _mockMapperProduto.Setup(m => m.MapperEntityToDto(produto)).Returns(produtoDto);

            // Act
            var result = await _applicationServiceProduto.GetById(1);

            // Assert
            Assert.Equal(produtoDto, result);
        }

        [Fact]
        public async Task Remove_ShouldCallServiceRemove()
        {
            // Arrange
            var produtoDto = _produtoDtos.First();
            var produto = _produtos.First();
            _mockMapperProduto.Setup(m => m.MapperDtoToEntity(produtoDto)).Returns(produto);

            // Act
            await _applicationServiceProduto.Remove(produtoDto);

            // Assert
            _mockServiceProduto.Verify(s => s.Remove(produto), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldCallServiceUpdate()
        {
            // Arrange
            var produtoDto = _produtoDtos.First();
            var produto = _produtos.First();
            _mockMapperProduto.Setup(m => m.MapperDtoToEntity(produtoDto)).Returns(produto);

            // Act
            await _applicationServiceProduto.Update(produtoDto);

            // Assert
            _mockServiceProduto.Verify(s => s.Update(produto), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldNotAddProduto_WhenProdutoDtoIsNull()
        {
            // Arrange
            ProdutoDto produtoDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _applicationServiceProduto.Add(produtoDto));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {
            // Arrange
            _mockServiceProduto.Setup(s => s.GetById(It.IsAny<uint>())).ReturnsAsync((Produto)null);

            // Act
            var result = await _applicationServiceProduto.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_ShouldNotUpdateProduto_WhenProdutoDtoIsNull()
        {
            // Arrange
            ProdutoDto produtoDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _applicationServiceProduto.Update(produtoDto));
        }
    }
}
