using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<BaseContext> _dbContextOptionsBuilder;

        public GenericRepository() => _dbContextOptionsBuilder = new DbContextOptions<BaseContext>();

        public async Task Add(T obj)
        {
            using (var data = new BaseContext(_dbContextOptionsBuilder))
            {
                data.Set<T>().Add(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new BaseContext(_dbContextOptionsBuilder))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new BaseContext(_dbContextOptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new BaseContext(_dbContextOptionsBuilder))
            {
                //AsNoTracking: Não efetua o rastreamento da entidade, não a armazenando em cache.
                //Ideal para utilizar em consultas que são somente leitura.
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T obj)
        {
            using (var data = new BaseContext(_dbContextOptionsBuilder))
            {
                data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }

        #region Dispose

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~GenericRepository()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
