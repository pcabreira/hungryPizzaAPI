using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Core.Services;
using hungryPizza.Test.Builder;
using Moq;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using hungryPizza.Infra.Repositories;
using hungryPizza.Infra.Data;
using System.Collections.Generic;

namespace hungryPizza.Test
{
    public class ClientesTest
    {
        private readonly ClientesService _service;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();

        public ClientesTest()
        {
            _service = new ClientesService(_mockUnitOfWork.Object);
        }

        [Fact(DisplayName = "Retorna cliente por e-mail")]
        public void GetClientePorEmail()
        {
            var cliente = new ClientesBuilder().GetCliente(1);

            var listclientes = new List<Clientes>();
            listclientes.Add(cliente);

            _mockUnitOfWork.Setup(x => x.ClientesRepository.GetAll()).Returns(listclientes);

            var clienteFromRepo = _service.GetClientePorEmail(cliente.Email);

            Assert.True(clienteFromRepo != null);
            Assert.Equal("cliente@cliente.com.br", clienteFromRepo.Email);
        }
    }
}
