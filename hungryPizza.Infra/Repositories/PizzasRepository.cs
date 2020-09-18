using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Infra.Repositories
{
    public class PizzasRepository : IPizzasRepository
    {
        private readonly hungrypizzadbContext _context;
        public PizzasRepository(hungrypizzadbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pizzas>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }
    }
}
