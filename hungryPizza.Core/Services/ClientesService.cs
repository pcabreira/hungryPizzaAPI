using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hungryPizza.Core.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Clientes>> GetClientes()
        {
            return await _unitOfWork.ClientesRepository.GetAllAsync();
        }

        public async Task<Clientes> GetClientePorId(int idCliente)
        {
            return await _unitOfWork.ClientesRepository.GetById(idCliente);
        }

        public Clientes GetClientePorEmail(string email)
        {
            return _unitOfWork.ClientesRepository.GetAll()
                                                 .Where(x => x.Email == email)
                                                 .FirstOrDefault();
        }

        public async Task InserirCliente(Clientes cliente)
        {
            await _unitOfWork.ClientesRepository.Add(cliente);
        }
    }
}
