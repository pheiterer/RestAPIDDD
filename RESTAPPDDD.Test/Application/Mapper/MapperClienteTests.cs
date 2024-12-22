using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Mappers;
using RestAPIDDD.Domain.Entities;

namespace RESTAPPDDD.Test.Application.Mapper
{
    public class MapperClienteTests
    {
        private readonly MapperCliente _mapperCliente;

        public MapperClienteTests()
        {
            _mapperCliente = new MapperCliente();
        }

        [Fact]
        public void MapperDtoToEntity_ShouldMapCorrectly()
        {
            // Arrange
            var clienteDto = new ClienteDto
            {
                Id = 1,
                Nome = "John",
                Sobrenome = "Doe",
                Email = "john.doe@example.com"
            };

            // Act
            var result = _mapperCliente.MapperDtoToEntity(clienteDto);

            // Assert
            Assert.Equal(clienteDto.Id, result.Id);
            Assert.Equal(clienteDto.Nome, result.Nome);
            Assert.Equal(clienteDto.Sobrenome, result.Sobrenome);
            Assert.Equal(clienteDto.Email, result.Email);
        }

        [Fact]
        public void MapperEntityToDto_ShouldMapCorrectly()
        {
            // Arrange
            var cliente = new Cliente
            {
                Id = 1,
                Nome = "John",
                Sobrenome = "Doe",
                Email = "john.doe@example.com"
            };

            // Act
            var result = _mapperCliente.MapperEntityToDto(cliente);

            // Assert
            Assert.Equal(cliente.Id, result.Id);
            Assert.Equal(cliente.Nome, result.Nome);
            Assert.Equal(cliente.Sobrenome, result.Sobrenome);
            Assert.Equal(cliente.Email, result.Email);
        }

        [Fact]
        public void MapperListClientesDto_ShouldMapCorrectly()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com" },
                new Cliente { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com" }
            };

            // Act
            var result = _mapperCliente.MapperListClientesDto(clientes);

            // Assert
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal(clientes[0].Id, item.Id);
                    Assert.Equal(clientes[0].Nome, item.Nome);
                    Assert.Equal(clientes[0].Sobrenome, item.Sobrenome);
                    Assert.Equal(clientes[0].Email, item.Email);
                },
                item =>
                {
                    Assert.Equal(clientes[1].Id, item.Id);
                    Assert.Equal(clientes[1].Nome, item.Nome);
                    Assert.Equal(clientes[1].Sobrenome, item.Sobrenome);
                    Assert.Equal(clientes[1].Email, item.Email);
                });
        }
    }
}
