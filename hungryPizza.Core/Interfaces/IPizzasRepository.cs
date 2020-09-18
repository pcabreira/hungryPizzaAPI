using hungryPizza.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IPizzasRepository
    {
        Task<IEnumerable<Pizzas>> GetPizzas();
    }
}
