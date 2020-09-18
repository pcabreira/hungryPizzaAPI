using hungryPizza.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetClientes();
        Task<Clientes> GetClientePorId(int idCliente);
        Clientes GetClientePorEmail(string email);
        Task InserirCliente(Clientes cliente);
    }
}
