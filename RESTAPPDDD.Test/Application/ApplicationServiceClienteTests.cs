using Moq;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Application;
using RestAPIDDD.Doamin.Core.Interfaces.Services;
using RestAPIDDD.Domain.Entities;

namespace RESTAPPDDD.Test.Application
{
    public class ApplicationServiceClienteTests
    {
        private readonly Mock<IServiceCliente> _mockServiceCliente;
        private readonly Mock<IMapperCliente> _mockMapperCliente;
        private readonly ApplicationServiceCliente _applicationServiceCliente;
        private readonly List<Cliente> _clientes;
        private readonly List<ClienteDto> _clienteDtos;

        public ApplicationServiceClienteTests()
        {
            _mockServiceCliente = new Mock<IServiceCliente>();
            _mockMapperCliente = new Mock<IMapperCliente>();
            _applicationServiceCliente = new ApplicationServiceCliente(_mockServiceCliente.Object, _mockMapperCliente.Object);
            _clientes =
                [
                    new Cliente { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com", IsAtivo = true },
                    new Cliente { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com", IsAtivo = false }
                ];
            _clienteDtos =
                [
                    new ClienteDto { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com" },
                    new ClienteDto { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com" }
                ];
        }

        [Fact]
        public async Task Add_ShouldCallServiceAdd()
        {
            // Arrange
            var clienteDto = new ClienteDto { Id = 3, Nome = "Bob", Sobrenome = "Smith", Email = "bob.smith@example.com" };
            var cliente = new Cliente { Id = 3, Nome = "Bob", Sobrenome = "Smith", Email = "bob.smith@example.com" };
            _mockMapperCliente.Setup(m => m.MapperDtoToEntity(clienteDto)).Returns(cliente);

            // Act
            await _applicationServiceCliente.Add(clienteDto);

            // Assert
            _mockServiceCliente.Verify(s => s.Add(cliente), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllClientes()
        {
            // Arrange
            _mockServiceCliente.Setup(s => s.GetAll()).ReturnsAsync(_clientes);
            _mockMapperCliente.Setup(m => m.MapperListClientesDto(_clientes)).Returns(_clienteDtos);

            // Act
            var result = await _applicationServiceCliente.GetAll();

            // Assert
            Assert.Equal(_clienteDtos, result);
        }

        [Fact]
        public async Task GetById_ShouldReturnCliente()
        {
            // Arrange
            var cliente = _clientes.First();
            var clienteDto = _clienteDtos.First();
            _mockServiceCliente.Setup(s => s.GetById(1)).ReturnsAsync(cliente);
            _mockMapperCliente.Setup(m => m.MapperEntityToDto(cliente)).Returns(clienteDto);

            // Act
            var result = await _applicationServiceCliente.GetById(1);

            // Assert
            Assert.Equal(clienteDto, result);
        }

        [Fact]
        public async Task Remove_ShouldCallServiceRemove()
        {
            // Arrange
            var clienteDto = _clienteDtos.First();
            var cliente = _clientes.First();
            _mockMapperCliente.Setup(m => m.MapperDtoToEntity(clienteDto)).Returns(cliente);

            // Act
            await _applicationServiceCliente.Remove(clienteDto);

            // Assert
            _mockServiceCliente.Verify(s => s.Remove(cliente), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldCallServiceUpdate()
        {
            // Arrange
            var clienteDto = _clienteDtos.First();
            var cliente = _clientes.First();
            _mockMapperCliente.Setup(m => m.MapperDtoToEntity(clienteDto)).Returns(cliente);

            // Act
            await _applicationServiceCliente.Update(clienteDto);

            // Assert
            _mockServiceCliente.Verify(s => s.Update(cliente), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldNotAddCliente_WhenClienteDtoIsNull()
        {
            // Arrange
            ClienteDto clienteDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _applicationServiceCliente.Add(clienteDto));
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenClienteDoesNotExist()
        {
            // Arrange
            _mockServiceCliente.Setup(s => s.GetById(It.IsAny<uint>())).ReturnsAsync((Cliente)null);

            // Act
            var result = await _applicationServiceCliente.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Update_ShouldNotUpdateCliente_WhenClienteDtoIsNull()
        {
            // Arrange
            ClienteDto clienteDto = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _applicationServiceCliente.Update(clienteDto));
        }
    }
}
