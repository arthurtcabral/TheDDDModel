using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces.Generics
{
    public interface IGenericApp<T> where T : class
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task<T> GetEntityById(int id);
        Task<List<T>> List();
    }
}
