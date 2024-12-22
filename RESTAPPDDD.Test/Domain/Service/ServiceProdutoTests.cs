using Moq;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Domain.Entities;
using RestAPIDDD.Domain.Service;

namespace RESTAPPDDD.Test.Domain.Service
{
    public class ServiceProdutoTests
    {
        private readonly Mock<IRepositoryProduto> _mockRepository;
        private readonly ServiceProduto _serviceProduto;
        private readonly List<Produto> _produtos;

        public ServiceProdutoTests()
        {
            _mockRepository = new Mock<IRepositoryProduto>();
            _serviceProduto = new ServiceProduto(_mockRepository.Object);
            _produtos = new List<Produto>
                {
                    new Produto { Id = 1, Nome = "Produto 1", Valor = 10.0m, IsDisponivel = true },
                    new Produto { Id = 2, Nome = "Produto 2", Valor = 20.0m, IsDisponivel = false }
                };
        }

        [Fact]
        public async Task Add_ShouldCallRepositoryAdd()
        {
            // Arrange
            var produto = new Produto { Id = 1, Nome = "Produto 1", Valor = 10.0m, IsDisponivel = true };

            // Act
            await _serviceProduto.Add(produto);

            // Assert
            _mockRepository.Verify(r => r.Add(produto), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProducts()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetAll()).ReturnsAsync(_produtos);

            // Act
            var result = await _serviceProduto.GetAll();

            // Assert
            Assert.Equal(_produtos, result);
        }

        [Fact]
        public async Task GetById_ShouldReturnProduct()
        {
            // Arrange
            var produto = _produtos.First();
            _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync(produto);

            // Act
            var result = await _serviceProduto.GetById(1);

            // Assert
            Assert.Equal(produto, result);
        }

        [Fact]
        public async Task Remove_ShouldCallRepositoryRemove()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            await _serviceProduto.Remove(produto);

            // Assert
            _mockRepository.Verify(r => r.Remove(produto), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            await _serviceProduto.Update(produto);

            // Assert
            _mockRepository.Verify(r => r.Update(produto), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldNotAddProduto_WhenProdutoIsNull()
        {
            // Arrange
            Produto produto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _serviceProduto.Add(produto));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetById(It.IsAny<uint>())).ReturnsAsync((Produto)null);

            // Act
            var result = await _serviceProduto.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_ShouldNotUpdateProduto_WhenProdutoIsNull()
        {
            // Arrange
            Produto produto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _serviceProduto.Update(produto));
        }
    }
}
