using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hungryPizza.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly hungrypizzadbContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(hungrypizzadbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
