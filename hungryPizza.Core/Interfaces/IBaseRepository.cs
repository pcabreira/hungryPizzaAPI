using hungryPizza.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task Add(T entity);
    }
}
