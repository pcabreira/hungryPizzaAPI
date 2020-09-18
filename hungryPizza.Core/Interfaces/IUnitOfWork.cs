using hungryPizza.Core.Entities;
using System;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Pedidos> PedidosRepository { get; }
        IBaseRepository<Clientes> ClientesRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
