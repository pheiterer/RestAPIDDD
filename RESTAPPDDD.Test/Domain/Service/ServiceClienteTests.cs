using Moq;
using RestAPIDDD.Domain.Entities;
using RestAPIDDD.Domain.Service;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;

namespace RESTAPPDDD.Test.Domain.Service
{
    public class ServiceClienteTests
    {
        private readonly Mock<IRepositoryCliente> _mockRepository;
        private readonly ServiceCliente _serviceCliente;
        private readonly List<Cliente> _clientes;

        public ServiceClienteTests()
        {
            _mockRepository = new Mock<IRepositoryCliente>();
            _serviceCliente = new ServiceCliente(_mockRepository.Object);
            _clientes =
            [
                new Cliente { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com", IsAtivo = true },
                new Cliente { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com", IsAtivo = false }
            ];
        }

        [Fact]
        public async Task Add_ShouldAddCliente()
        {
            // Arrange
            var cliente = new Cliente { Id = 3, Nome = "Bob", Sobrenome = "Smith", Email = "bob.smith@example.com", IsAtivo = true };

            // Act
            await _serviceCliente.Add(cliente);

            // Assert
            _mockRepository.Verify(m => m.Add(cliente), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllClientes()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_clientes);

            // Act
            var result = await _serviceCliente.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(_clientes, result);
        }

        [Fact]
        public async Task GetById_ShouldReturnCliente()
        {
            // Arrange
            var cliente = _clientes.First();
            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(cliente);

            // Act
            var result = await _serviceCliente.GetById(1);

            // Assert
            Assert.Equal(cliente, result);
        }

        [Fact]
        public async Task Remove_ShouldRemoveCliente()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            await _serviceCliente.Remove(cliente);

            // Assert
            _mockRepository.Verify(m => m.Remove(cliente), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldUpdateCliente()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            await _serviceCliente.Update(cliente);

            // Assert
            _mockRepository.Verify(m => m.Update(cliente), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldNotAddCliente_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _serviceCliente.Add(cliente));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenClienteDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<uint>())).ReturnsAsync((Cliente)null);

            // Act
            var result = await _serviceCliente.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_ShouldNotUpdateCliente_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _serviceCliente.Update(cliente));
        }

    }
}
