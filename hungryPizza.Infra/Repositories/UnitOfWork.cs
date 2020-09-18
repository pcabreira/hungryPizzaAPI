using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Infra.Data;
using System;
using System.Threading.Tasks;

namespace hungryPizza.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly hungrypizzadbContext _context;
        private readonly IBaseRepository<Pedidos> _pedidosRepository;
        private readonly IBaseRepository<Clientes> _clientesRepository;

        public UnitOfWork(hungrypizzadbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Pedidos> PedidosRepository => _pedidosRepository ?? new BaseRepository<Pedidos>(_context);

        public IBaseRepository<Clientes> ClientesRepository => _clientesRepository ?? new BaseRepository<Clientes>(_context);

        //public IBaseRepository<Pizzas> PizzasRepository => _pizzasRepository ?? new BaseRepository<Pizzas>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
