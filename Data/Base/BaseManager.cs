using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Data.Base
{
    public abstract class BaseManager<T> where T : class
    {
        private static ApplicationDbContext contextInstance = null;

        public static ApplicationDbContext contextSingleton { 
            
            get
            {
                if(contextInstance == null)
                {
                    contextInstance = new ApplicationDbContext();
                }
                return contextInstance;
            }
        }

        public abstract Task<List<T>> BuscarListaAsync();
        public abstract Task<T> BuscarAsync();
        public abstract Task<bool> Borrar(T entity);


        public async Task<bool> Guardar(T entity, int id)
        {
            if(id == 0)
            {
                contextSingleton.Entry(entity).State = EntityState.Added;
            }
            else
            {
                contextSingleton.Entry(entity).State = EntityState.Modified;
            }

            var resultado = await contextSingleton.SaveChangesAsync() > 0;

            contextSingleton.Entry(entity).State = EntityState.Detached;
            return resultado;   
        }
    }
}
