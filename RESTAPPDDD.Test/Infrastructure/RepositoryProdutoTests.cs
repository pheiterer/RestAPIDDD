using Moq;
using RestAPIDDD.Domain.Entities;
using RestAPIDDD.Infrastructure.Data.Repositories;
using RestAPIDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace RESTAPPDDD.Test.Infrastructure
{
    public class RepositoryProdutoTests
    {
        private readonly Mock<SqlContext> _mockContext;
        private readonly Mock<DbSet<Produto>> _mockSet;
        private readonly RepositoryProduto _repositoryProduto;
        private readonly List<Produto> _produtos;

        public RepositoryProdutoTests()
        {
            _mockSet = new Mock<DbSet<Produto>>();
            var options = new DbContextOptionsBuilder<SqlContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _mockContext = new Mock<SqlContext>(options);
            _mockContext.Setup(m => m.Set<Produto>()).Returns(_mockSet.Object);
            _repositoryProduto = new RepositoryProduto(_mockContext.Object);

            _produtos =
            [
                new Produto { Id = 1, Nome = "Produto1", Valor = 10.0m, IsDisponivel = true },
                new Produto { Id = 2, Nome = "Produto2", Valor = 20.0m, IsDisponivel = false }
            ];
        }

        [Fact]
        public async Task Add_ShouldAddProduto()
        {
            // Arrange
            var produto = new Produto { Id = 3, Nome = "Produto3", Valor = 30.0m, IsDisponivel = true };

            // Act
            await _repositoryProduto.Add(produto);

            // Assert
            _mockSet.Verify(m => m.AddAsync(produto, default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProdutos()
        {

            var mockSet = new Mock<DbSet<Produto>>();
            // Arrange
            mockSet.As<IQueryable<Produto>>().Setup(m => m.Provider).Returns(_produtos.AsQueryable().Provider);
            mockSet.As<IQueryable<Produto>>().Setup(m => m.Expression).Returns(_produtos.AsQueryable().Expression);
            mockSet.As<IQueryable<Produto>>().Setup(m => m.ElementType).Returns(_produtos.AsQueryable().ElementType);
            mockSet.As<IQueryable<Produto>>().Setup(m => m.GetEnumerator()).Returns(_produtos.AsQueryable().GetEnumerator());

            _mockContext.Setup(m => m.Set<Produto>()).Returns(mockSet.Object);

            // Act
            var result = await _repositoryProduto.GetAll();

            // Assert
            var lista = result.ToList();
            Assert.Equal(2, lista.Count);
            Assert.Equal(_produtos, lista);
        }

        [Fact]
        public async Task GetById_ShouldReturnProduto()
        {
            // Arrange
            var produto = _produtos.First();
            _mockSet.Setup(m => m.FindAsync((uint)1)).ReturnsAsync(produto);

            // Act
            var result = await _repositoryProduto.GetById(1);

            // Assert
            Assert.Equal(produto, result);
        }

        [Fact]
        public async Task Remove_ShouldRemoveProduto()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            await _repositoryProduto.Remove(produto);

            // Assert
            _mockSet.Verify(m => m.Remove(produto), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldUpdateProduto()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            await _repositoryProduto.Update(produto);

            // Assert
            _mockContext.Verify(m => m.SetModified(produto), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }
        [Fact]
        public async Task Add_ShouldNotAddProduto_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryProduto.Add(null));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {
            // Arrange
            _mockSet.Setup(m => m.FindAsync((uint)3)).ReturnsAsync((Produto)null);

            // Act
            var result = await _repositoryProduto.GetById(3);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryProduto.Remove(null));
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryProduto.Update(null));
        }
    }
}
