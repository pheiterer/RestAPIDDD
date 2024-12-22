using Microsoft.EntityFrameworkCore;
using Moq;
using RestAPIDDD.Domain.Entities;
using RestAPIDDD.Infrastructure.Data.Repositories;
using RestAPIDDD.Infrastructure.Data;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;

namespace RESTAPPDDD.Test.Infrastructure
{
    public class RepositoryClienteTest
    {
        private Mock<DbSet<Cliente>> _mockSet;
        private readonly Mock<SqlContext> _mockContext;
        private readonly RepositoryCliente _repositoryCliente;
        private List<Cliente> _clientes;

        public RepositoryClienteTest()
        {
            _mockSet = new Mock<DbSet<Cliente>>();
            var options = new DbContextOptionsBuilder<SqlContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _mockContext = new Mock<SqlContext>(options);
            _mockContext.Setup(m => m.Set<Cliente>()).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.SetModified(It.IsAny<Cliente>()));
            _repositoryCliente = new RepositoryCliente(_mockContext.Object);
            InitializerClientes();
        }

        private void InitializerClientes()
        {
            _clientes = new List<Cliente>
                {
                    new() { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com" },
                    new() { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com" }
                };
        }

        [Fact]
        public async Task Add_ShouldAddCliente()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            await _repositoryCliente.Add(cliente);

            // Assert
            _mockSet.Verify(m => m.AddAsync(cliente, default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEntities()
        {
            var clientes = _clientes.AsQueryable();

            var mockSet = new Mock<DbSet<Cliente>>();
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Provider).Returns(clientes.Provider);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(clientes.Expression);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(clientes.ElementType);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(clientes.GetEnumerator());

            _mockContext.Setup(m => m.Set<Cliente>()).Returns(mockSet.Object);

            var result = await _repositoryCliente.GetAll();

            var lista = result.ToList();

            Assert.Equal(2, lista.Count);
            Assert.Equal(_clientes, lista);
        }

        [Fact]
        public async Task GetById_ShouldReturnCliente_WhenClienteExists()
        {
            // Arrange
            var cliente = _clientes.First();
            _mockSet.Setup(m => m.FindAsync((uint)1)).ReturnsAsync(cliente);

            // Act
            var result = await _repositoryCliente.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cliente.Id, result.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenClienteDoesNotExist()
        {
            // Arrange
            _mockSet.Setup(m => m.FindAsync(1)).ReturnsAsync((Cliente?)null);

            // Act
            var result = await _repositoryCliente.GetById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Remove_ShouldRemoveCliente()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            await _repositoryCliente.Remove(cliente);

            // Assert
            _mockSet.Verify(m => m.Remove(cliente), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldUpdateCliente()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            await _repositoryCliente.Update(cliente);

            // Assert
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldNotAddProduto_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryCliente.Add(null));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenProdutoDoesNotExist()
        {
            // Arrange
            _mockSet.Setup(m => m.FindAsync((uint)3)).ReturnsAsync((Cliente)null);

            // Act
            var result = await _repositoryCliente.GetById(3);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Remove_ShouldThrowException_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryCliente.Remove(null));
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenProdutoIsNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repositoryCliente.Update(null));
        }
    }
}
