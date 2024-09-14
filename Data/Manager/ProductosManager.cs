using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class ProductosManager : BaseManager<Productos>
    {
        public override Task<bool> Borrar(Productos entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Productos> BuscarAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Productos>> BuscarListaAsync()
        {
            return  contextSingleton.Productos.Where(x => x.Activo == true).ToList();
        }
    }
}
