using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contract.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindById(object id);
        Task Delete(T entity);
        Task<T> Add(T entity);  


        Task Update(T entity);   
    }
}
